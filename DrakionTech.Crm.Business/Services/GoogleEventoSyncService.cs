using DrakionTech.Crm.Business.Services;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

public class GoogleEventoSyncService
{
    private readonly ApplicationDbContext _context;
    private readonly IGoogleCalendarService _googleService;
    private readonly AzureBlobService _azureBlobService;
    private readonly GoogleDriveService _driveService;

    private static readonly Regex FileIdRegex1 = new(@"/d/([a-zA-Z0-9_-]+)", RegexOptions.Compiled);
    private static readonly Regex FileIdRegex2 = new(@"[?&]id=([a-zA-Z0-9_-]+)", RegexOptions.Compiled);

    public GoogleEventoSyncService(
        ApplicationDbContext context,
        IGoogleCalendarService googleService,
        AzureBlobService azureBlobService,
        GoogleDriveService driveService)
    {
        _context = context;
        _googleService = googleService;
        _azureBlobService = azureBlobService;
        _driveService = driveService;
    }

    public async Task SincronizarAsync()
    {
        var eventosGoogle = await _googleService.GetEventosAsync();

        var eventosDb = await _context.GoogleEventos
            .Include(x => x.Archivos)
            .ToListAsync();

        var eventosDbDict = eventosDb.ToDictionary(x => x.GoogleEventId);

        foreach (var e in eventosGoogle)
        {
            if (!eventosDbDict.TryGetValue(e.GoogleEventId, out var existente))
            {
                var nuevoEvento = new GoogleEvento
                {
                    GoogleEventId = e.GoogleEventId,
                    Titulo = e.Titulo,
                    FechaInicio = e.FechaInicio,
                    FechaFin = e.FechaFin,
                    Descripcion = e.Descripcion,
                    Ubicacion = e.Ubicacion,
                    FechaImportacion = DateTime.Now,
                    LastUpdatedGoogle = e.LastUpdatedGoogle,
                    Archivos = new List<GoogleEventoArchivo>()
                };

                if (e.Archivos != null && e.Archivos.Any())
                {
                    var tareas = e.Archivos.Select(ProcesarArchivoAsync);
                    var archivosProcesados = await Task.WhenAll(tareas);

                    nuevoEvento.Archivos.AddRange(archivosProcesados);
                }

                _context.GoogleEventos.Add(nuevoEvento);
            }
            else
            {
                if (existente.LastUpdatedGoogle == e.LastUpdatedGoogle)
                    continue;

                existente.Titulo = e.Titulo;
                existente.FechaInicio = e.FechaInicio;
                existente.FechaFin = e.FechaFin;
                existente.Descripcion = e.Descripcion;
                existente.Ubicacion = e.Ubicacion;
                existente.LastUpdatedGoogle = e.LastUpdatedGoogle;

                if (e.Archivos != null && e.Archivos.Any())
                {
                    var existentesIds = existente.Archivos
                        .Select(a => a.GoogleFileId)
                        .ToHashSet();

                    var nuevos = e.Archivos
                        .Where(url => !existentesIds.Contains(ExtraerFileId(url)))
                        .ToList();

                    if (nuevos.Any())
                    {
                        var tareas = nuevos.Select(ProcesarArchivoAsync);
                        var archivos = await Task.WhenAll(tareas);

                        existente.Archivos.AddRange(archivos);
                    }
                }
            }
        }

        if (_context.ChangeTracker.HasChanges())
        {
            await _context.SaveChangesAsync();
        }
    }

    private async Task<GoogleEventoArchivo> ProcesarArchivoAsync(string url)
    {
        var fileId = ExtraerFileId(url);

        var (bytes, extension, contentType) =
            await _driveService.DescargarArchivoAsync(fileId, url);

        var nombre = await _driveService.ObtenerNombreAsync(fileId, extension);

        var azureUrl = await SubirAAzure(bytes, nombre, contentType);

        return new GoogleEventoArchivo
        {
            Url = azureUrl,
            Nombre = nombre,
            GoogleFileId = fileId
        };
    }

    private string ExtraerFileId(string url)
    {
        var match = FileIdRegex1.Match(url);
        if (match.Success) return match.Groups[1].Value;

        match = FileIdRegex2.Match(url);
        if (match.Success) return match.Groups[1].Value;

        throw new InvalidOperationException($"No se pudo extraer fileId de: {url}");
    }

    private async Task<string> SubirAAzure(byte[] bytes, string nombreArchivo, string contentType)
    {
        var fileName = $"{Guid.NewGuid()}_{nombreArchivo}";
        using var stream = new MemoryStream(bytes);
        return await _azureBlobService.UploadAsync(stream, fileName, contentType);
    }
}