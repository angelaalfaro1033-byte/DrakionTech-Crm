using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Area;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class AreaService : IAreaService
{
    private readonly ApplicationDbContext _db;

    public AreaService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ResultadoPaginacion<AreaListDto>> ObtenerTodasConPaginacionAsync(string? busqueda = null, bool? soloActivas = null, int pagina = 1, int tamañoPagina = 10)
    {
        var query = _db.Areas
            .Include(a => a.Responsable)
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
                TotalUsuarios = a.Usuarios.Count()
            })
            .PaginarAsync(pagina, tamañoPagina);
    }

    // ─────────────────────────────────────────────
    // OBTENER TODAS
    // ─────────────────────────────────────────────
    public async Task<IEnumerable<AreaListDto>> ObtenerTodasAsync(string? busqueda = null, bool? soloActivas = null)
    {
        var query = _db.Areas
            .Include(a => a.Responsable)
            .AsQueryable();

        // Filtro por estado
        if (soloActivas.HasValue)
            query = query.Where(a => a.Activa == soloActivas.Value);

        // Búsqueda case-insensitive
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
                TotalUsuarios = a.Usuarios.Count()
            })
            .ToListAsync();
    }

    // ─────────────────────────────────────────────
    // OBTENER POR ID
    // ─────────────────────────────────────────────
    public async Task<AreaDto?> ObtenerPorIdAsync(int id)
    {
        var area = await _db.Areas
            .Include(a => a.Responsable)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (area is null) return null;

        return MapToDto(area);
    }

    // ─────────────────────────────────────────────
    // CREAR
    // ─────────────────────────────────────────────
    public async Task<AreaDto> CrearAsync(CrearAreaDto dto)
    {
        // Validación insensitive de nombre duplicado
        await ValidarNombreUnicoAsync(dto.Nombre, excludeId: null);

        // Validar responsable (si se indica)
        if (dto.ResponsableId.HasValue)
            await ValidarResponsableExisteAsync(dto.ResponsableId.Value);

        var area = new Area
        {
            Nombre = dto.Nombre.Trim(),
            Descripcion = dto.Descripcion?.Trim(),
            Activa = dto.Activa,
            ResponsableId = dto.ResponsableId,
            FechaCreacion = DateTime.UtcNow
        };

        _db.Areas.Add(area);
        await _db.SaveChangesAsync();

        return (await ObtenerPorIdAsync(area.Id))!;
    }

    // ─────────────────────────────────────────────
    // ACTUALIZAR
    // ─────────────────────────────────────────────
    public async Task<AreaDto> ActualizarAsync(int id, ActualizarAreaDto dto)
    {
        var area = await _db.Areas.FindAsync(id)
            ?? throw new KeyNotFoundException($"No se encontró el área con ID {id}.");

        await ValidarNombreUnicoAsync(dto.Nombre, excludeId: id);

        if (dto.ResponsableId.HasValue)
            await ValidarResponsableExisteAsync(dto.ResponsableId.Value);

        area.Nombre = dto.Nombre.Trim();
        area.Descripcion = dto.Descripcion?.Trim();
        area.Activa = dto.Activa;
        area.ResponsableId = dto.ResponsableId;
        area.FechaModificacion = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return (await ObtenerPorIdAsync(id))!;
    }

    // ─────────────────────────────────────────────
    // ELIMINAR
    // ─────────────────────────────────────────────
    public async Task CambiarEstadoAsync(int id, bool activa)
    {
        var area = await _db.Areas.FindAsync(id)
            ?? throw new KeyNotFoundException($"Área {id} no encontrada.");

        area.Activa = activa;
        area.FechaModificacion = DateTime.UtcNow;

        await _db.SaveChangesAsync();
    }

    // ─────────────────────────────────────────────
    // HELPERS PÚBLICOS
    // ─────────────────────────────────────────────
    public async Task<bool> NombreExisteAsync(string nombre, int? excluirId = null)
    {
        var normalizado = nombre.Trim().ToLower();
        return await _db.Areas.AnyAsync(a =>
            a.Nombre.ToLower() == normalizado &&
            (!excluirId.HasValue || a.Id != excluirId.Value));
    }

    // ─────────────────────────────────────────────
    // HELPERS PRIVADOS
    // ─────────────────────────────────────────────
    private async Task ValidarNombreUnicoAsync(string nombre, int? excludeId)
    {
        if (await NombreExisteAsync(nombre, excludeId))
            throw new InvalidOperationException(
                $"Ya existe un área con el nombre '{nombre.Trim()}'. Los nombres de área deben ser únicos.");
    }

    private async Task ValidarResponsableExisteAsync(int responsableId)
    {
        var existe = await _db.Usuarios.AnyAsync(u => u.Id == responsableId);
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
        FechaModificacion = a.FechaModificacion
    };
}