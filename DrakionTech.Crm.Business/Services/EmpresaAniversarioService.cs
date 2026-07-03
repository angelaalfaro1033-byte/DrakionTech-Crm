using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrakionTech.Crm.Business.Services.Empresas;

public interface IEmpresaAniversarioService
{
    Task ProcesarAniversariosAsync(CancellationToken ct = default);
}

public class EmpresaAniversarioService : IEmpresaAniversarioService
{
    private const string NombrePlantilla = "empresa-aniversario";

    private readonly IEmpresaRepository _empresaRepository;
    private readonly IEmailService _emailService;
    private readonly IHistorialEmpresaService _historialService;
    private readonly ILogger<EmpresaAniversarioService> _logger;

    public EmpresaAniversarioService(
        IEmpresaRepository empresaRepository,
        IEmailService emailService,
        IHistorialEmpresaService historialService,
        ILogger<EmpresaAniversarioService> logger)
    {
        _empresaRepository = empresaRepository;
        _emailService = emailService;
        _historialService = historialService;
        _logger = logger;
    }

    public async Task ProcesarAniversariosAsync(CancellationToken ct = default)
    {
        var hoy = DateTime.Today;

        var empresas = await _empresaRepository.Query()
            .Where(e => e.Activa)
            .Where(e => e.FechaCreacionEmpresa.HasValue)
            .Where(e => !string.IsNullOrWhiteSpace(e.Correo))
            .Where(e => e.FechaCreacionEmpresa!.Value.Month == hoy.Month
                     && e.FechaCreacionEmpresa!.Value.Day == hoy.Day)
            .ToListAsync(ct);

        foreach (var empresa in empresas)
        {
            var anios = hoy.Year - empresa.FechaCreacionEmpresa!.Value.Year;
            if (anios <= 0)
                continue;

            // Clave única por empresa + año: evita reenvíos el mismo año
            // sin necesidad de una columna adicional en la tabla Empresas.
            var claveEvento = $"aniversario-empresa:{empresa.Id}:{hoy.Year}";

            var yaEnviado = await _historialService.ExisteEventoAsync(claveEvento, ct);
            if (yaEnviado)
                continue;

            try
            {
                await _emailService.EnviarPlantillaAsync(
                    empresa.Correo!,
                    NombrePlantilla,
                    new Dictionary<string, string>
                    {
                        ["nombre_empresa"] = empresa.Nombre,
                        ["anios"] = anios.ToString(),
                        ["fecha"] = hoy.ToString("dd/MM/yyyy")
                    });

                await _historialService.RegistrarAsync(new RegistrarHistorialEmpresaDto
                {
                    EmpresaId = empresa.Id,
                    TipoEvento = TipoEventoHistorialEmpresa.AniversarioEmpresaEnviado,
                    TituloEvento = "Correo de aniversario enviado",
                    DescripcionEvento = $"Se envió el correo de felicitación por {anios} año(s) al contacto principal ({empresa.Correo}).",
                    ModuloOrigen = ModuloOrigenHistorialEmpresa.Empresas,
                    RegistroOrigenId = empresa.Id,
                    ClaveEvento = claveEvento
                }, ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al enviar el correo de aniversario de la empresa {EmpresaId}", empresa.Id);

                // Se registra el intento fallido con una clave distinta para no bloquear
                // el reintento en la siguiente ejecución del job dentro del mismo día.
                await _historialService.RegistrarAsync(new RegistrarHistorialEmpresaDto
                {
                    EmpresaId = empresa.Id,
                    TipoEvento = TipoEventoHistorialEmpresa.AniversarioEmpresaFallido,
                    TituloEvento = "Falló el envío del correo de aniversario",
                    DescripcionEvento = $"No se pudo enviar el correo al contacto principal ({empresa.Correo}). Detalle: {ex.Message}",
                    ModuloOrigen = ModuloOrigenHistorialEmpresa.Empresas,
                    RegistroOrigenId = empresa.Id,
                    ClaveEvento = $"{claveEvento}:error:{DateTime.UtcNow:yyyyMMddHHmmss}"
                }, ct);
            }
        }
    }
}