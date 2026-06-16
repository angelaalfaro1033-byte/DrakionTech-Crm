using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Area;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class AreaService : IAreaService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

    public AreaService(IDbContextFactory<ApplicationDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<ResultadoPaginacion<AreaListDto>> ObtenerTodasConPaginacionAsync(string? busqueda = null, bool? soloActivas = null, int pagina = 1, int tamañoPagina = 10)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        var query = db.Areas
            .Include(a => a.Responsable)
            .Include(a => a.CreatedByUser)
            .Include(a => a.ModifiedByUser)
            .AsQueryable();

        if (soloActivas.HasValue)
            query = query.Where(a => a.Activa == soloActivas.Value);

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();

            query = query.Where(a =>
                a.Nombre.ToLower().Contains(term) ||
                (a.Descripcion != null && a.Descripcion.ToLower().Contains(term)) ||
                (a.Responsable != null &&
                    (a.Responsable.Nombre + " " + a.Responsable.Apellido)
                        .ToLower()
                        .Contains(term)));
        }

        return await query
            .OrderBy(a => a.Nombre)
            .Select(a => new AreaListDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Activa = a.Activa,
                ResponsableId = a.ResponsableId,
                ResponsableNombre = a.Responsable != null
                    ? $"{a.Responsable.Nombre} {a.Responsable.Apellido}"
                    : null,
                FechaCreacion = a.FechaCreacion,
                TotalUsuarios = a.Usuarios.Count(),
                AuditInfo = AuditInfoFactory.FromEntity(a)
            })
            .PaginarAsync(pagina, tamañoPagina);
    }

    // ─────────────────────────────────────────────
    // OBTENER TODAS
    // ─────────────────────────────────────────────
    public async Task<IEnumerable<AreaListDto>> ObtenerTodasAsync(string? busqueda = null, bool? soloActivas = null)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        var query = db.Areas
            .Include(a => a.Responsable)
            .Include(a => a.CreatedByUser)
            .Include(a => a.ModifiedByUser)
            .AsQueryable();

        if (soloActivas.HasValue)
            query = query.Where(a => a.Activa == soloActivas.Value);

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();
            query = query.Where(a =>
                a.Nombre.ToLower().Contains(term) ||
                (a.Descripcion != null && a.Descripcion.ToLower().Contains(term)) ||
                (a.Responsable != null && (a.Responsable.Nombre + " " + a.Responsable.Apellido).ToLower().Contains(term)));
        }

        return await query
            .OrderBy(a => a.Nombre)
            .Select(a => new AreaListDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Activa = a.Activa,
                ResponsableId = a.ResponsableId,
                ResponsableNombre = a.Responsable != null
                    ? $"{a.Responsable.Nombre} {a.Responsable.Apellido}"
                    : null,
                FechaCreacion = a.FechaCreacion,
                TotalUsuarios = a.Usuarios.Count(),
                AuditInfo = AuditInfoFactory.FromEntity(a)
            })
            .ToListAsync();
    }

    // ─────────────────────────────────────────────
    // OBTENER POR ID
    // ─────────────────────────────────────────────
    public async Task<AreaDto?> ObtenerPorIdAsync(int id)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        var area = await db.Areas
            .Include(a => a.Responsable)
            .Include(a => a.CreatedByUser)
            .Include(a => a.ModifiedByUser)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (area is null) return null;

        return MapToDto(area);
    }

    public async Task<AreaDto> CrearAsync(CrearAreaDto dto)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        await ValidarNombreUnicoAsync(db, dto.Nombre, excludeId: null);

        if (dto.ResponsableId.HasValue)
            await ValidarResponsableExisteAsync(db, dto.ResponsableId.Value);

        var area = new Area
        {
            Nombre = dto.Nombre.Trim(),
            Descripcion = dto.Descripcion?.Trim(),
            Activa = dto.Activa,
            ResponsableId = dto.ResponsableId,
            FechaCreacion = DateTime.UtcNow
        };

        db.Areas.Add(area);
        await db.SaveChangesAsync(); // aquí ya tiene Id

        // Actualizar AreaId del responsable
        if (dto.ResponsableId.HasValue)
        {
            var usuario = await db.Usuarios.FindAsync(dto.ResponsableId.Value);
            if (usuario is not null)
            {
                usuario.AreaId = area.Id;
                await db.SaveChangesAsync();
            }
        }

        return (await ObtenerPorIdAsync(area.Id))!;
    }

    public async Task<AreaDto> ActualizarAsync(int id, ActualizarAreaDto dto)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        var area = await db.Areas.FindAsync(id)
            ?? throw new KeyNotFoundException($"No se encontró el área con ID {id}.");

        await ValidarNombreUnicoAsync(db, dto.Nombre, excludeId: id);

        if (dto.ResponsableId.HasValue)
            await ValidarResponsableExisteAsync(db, dto.ResponsableId.Value);

        // Si cambia el responsable, limpiar AreaId del anterior
        if (area.ResponsableId.HasValue && area.ResponsableId != dto.ResponsableId)
        {
            var anterior = await db.Usuarios.FindAsync(area.ResponsableId.Value);
            if (anterior is not null)
                anterior.AreaId = null;
        }

        area.Nombre = dto.Nombre.Trim();
        area.Descripcion = dto.Descripcion?.Trim();
        area.Activa = dto.Activa;
        area.ResponsableId = dto.ResponsableId;
        area.FechaModificacion = DateTime.UtcNow;

        // Asignar AreaId al nuevo responsable
        if (dto.ResponsableId.HasValue)
        {
            var usuario = await db.Usuarios.FindAsync(dto.ResponsableId.Value);
            if (usuario is not null)
                usuario.AreaId = id;
        }

        await db.SaveChangesAsync();

        return (await ObtenerPorIdAsync(id))!;
    }

    public async Task CambiarEstadoAsync(int id, bool activa)
    {
        using var db = await _dbFactory.CreateDbContextAsync();

        var area = await db.Areas.FindAsync(id)
            ?? throw new KeyNotFoundException($"Área {id} no encontrada.");

        area.Activa = activa;
        area.FechaModificacion = DateTime.UtcNow;

        await db.SaveChangesAsync();
    }

    public async Task<bool> NombreExisteAsync(string nombre, int? excluirId = null)
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        return await NombreExisteInternoAsync(db, nombre, excluirId);
    }

    private static async Task<bool> NombreExisteInternoAsync(ApplicationDbContext db, string nombre, int? excluirId)
    {
        var normalizado = nombre.Trim().ToLower();
        return await db.Areas.AnyAsync(a =>
            a.Nombre.ToLower() == normalizado &&
            (!excluirId.HasValue || a.Id != excluirId.Value));
    }

    private static async Task ValidarNombreUnicoAsync(ApplicationDbContext db, string nombre, int? excludeId)
    {
        if (await NombreExisteInternoAsync(db, nombre, excludeId))
            throw new InvalidOperationException(
                $"Ya existe un área con el nombre '{nombre.Trim()}'. Los nombres de área deben ser únicos.");
    }

    private static async Task ValidarResponsableExisteAsync(ApplicationDbContext db, int responsableId)
    {
        var existe = await db.Usuarios.AnyAsync(u => u.Id == responsableId);
        if (!existe)
            throw new InvalidOperationException(
                $"El responsable con ID {responsableId} no existe en el sistema.");
    }

    private static AreaDto MapToDto(Area a) => new()
    {
        Id = a.Id,
        Nombre = a.Nombre,
        Descripcion = a.Descripcion,
        Activa = a.Activa,
        ResponsableId = a.ResponsableId,
        ResponsableNombre = a.Responsable != null
            ? $"{a.Responsable.Nombre} {a.Responsable.Apellido}"
            : null,
        FechaCreacion = a.FechaCreacion,
        FechaModificacion = a.FechaModificacion,
        AuditInfo = AuditInfoFactory.FromEntity(a)
    };
}