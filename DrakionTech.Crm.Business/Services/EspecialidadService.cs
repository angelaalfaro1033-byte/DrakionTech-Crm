using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Especialidad;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly ApplicationDbContext _db;

        public EspecialidadService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResultadoPaginacion<EspecialidadDto>> ObtenerTodosConPaginacionAsync(string? busqueda = null, bool? soloActivos = null, int pagina = 1, int tamañoPagina = 10)
        {
            var query = _db.Especialidades
                .Include(e => e.RolUsuario)
                .Include(e => e.CreatedByUser)
                .Include(e => e.ModifiedByUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(term));
            }

            if (soloActivos.HasValue)
                query = query.Where(e => e.Activo == soloActivos.Value);

            return await query
                .OrderBy(e => e.Nombre)
                .Select(e => new EspecialidadDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    RolUsuarioId = e.RolUsuarioId,
                    RolUsuarioNombre = e.RolUsuario != null ? e.RolUsuario.Nombre : null,
                    Activo = e.Activo,
                    AuditInfo = AuditInfoFactory.FromEntity(e)
                })
                .PaginarAsync(pagina, tamañoPagina);
        }

        public async Task<List<EspecialidadDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null)
        {
            var query = _db.Especialidades
                .Include(e => e.RolUsuario)
                .Include(e => e.CreatedByUser)
                .Include(e => e.ModifiedByUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(term));
            }

            if (soloActivos.HasValue)
                query = query.Where(e => e.Activo == soloActivos.Value);

            return await query
                .OrderBy(e => e.Nombre)
                .Select(e => new EspecialidadDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    RolUsuarioId = e.RolUsuarioId,
                    RolUsuarioNombre = e.RolUsuario != null ? e.RolUsuario.Nombre : null,
                    Activo = e.Activo,
                    AuditInfo = AuditInfoFactory.FromEntity(e)
                })
                .ToListAsync();
        }

        public async Task<EspecialidadDto> ObtenerPorIdAsync(int id)
        {
            var e = await _db.Especialidades
                .Include(e => e.RolUsuario)
                .Include(e => e.CreatedByUser)
                .Include(e => e.ModifiedByUser)
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            return MapToDto(e);
        }

        public async Task CrearAsync(EspecialidadDto dto)
        {
            var duplicado = await _db.Especialidades.AnyAsync(e =>
                e.Nombre.ToLower() == dto.Nombre.Trim().ToLower() &&
                e.RolUsuarioId == dto.RolUsuarioId);

            if (duplicado)
                throw new Exception(string.Format(MensajesError.EspecialidadDuplicada, dto.Nombre));

            var entidad = new Especialidad
            {
                Nombre = dto.Nombre.Trim(),
                Descripcion = dto.Descripcion?.Trim(),
                RolUsuarioId = dto.RolUsuarioId,
                Activo = true
            };

            _db.Especialidades.Add(entidad);
            await _db.SaveChangesAsync();
        }

        public async Task EditarAsync(EspecialidadDto dto)
        {
            var duplicado = await _db.Especialidades.AnyAsync(e =>
                e.Id != dto.Id &&
                e.Nombre.ToLower() == dto.Nombre.Trim().ToLower() &&
                e.RolUsuarioId == dto.RolUsuarioId);

            if (duplicado)
                throw new Exception(string.Format(MensajesError.EspecialidadDuplicada, dto.Nombre));

            var entidad = await _db.Especialidades.FindAsync(dto.Id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);

            entidad.Nombre = dto.Nombre.Trim();
            entidad.Descripcion = dto.Descripcion?.Trim();
            entidad.RolUsuarioId = dto.RolUsuarioId;
            entidad.Activo = dto.Activo;

            await _db.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var entidad = await _db.Especialidades.FindAsync(id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            entidad.Activo = true;
            await _db.SaveChangesAsync();
        }

        public async Task DesactivarAsync(int id)
        {
            var entidad = await _db.Especialidades.FindAsync(id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            entidad.Activo = false;
            await _db.SaveChangesAsync();
        }

        public async Task<EspecialidadDto> CrearYObtenerAsync(string nombre, int rolUsuarioId)
        {
            var normalizado = Normalizar(nombre);
            var existente = await _db.Especialidades
                .Include(e => e.RolUsuario)
                .FirstOrDefaultAsync(e =>
                    e.Nombre.ToLower() == normalizado &&
                    e.RolUsuarioId == rolUsuarioId);

            if (existente is not null)
                return MapToDto(existente);

            var nueva = new Especialidad
            {
                Nombre = nombre.Trim(),
                RolUsuarioId = rolUsuarioId,
                Activo = true
            };

            _db.Especialidades.Add(nueva);
            await _db.SaveChangesAsync();

            await _db.Entry(nueva).Reference(e => e.RolUsuario).LoadAsync();
            return MapToDto(nueva);
        }

        private static EspecialidadDto MapToDto(Especialidad e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Descripcion = e.Descripcion,
            RolUsuarioId = e.RolUsuarioId,
            RolUsuarioNombre = e.RolUsuario?.Nombre,
            Activo = e.Activo,
            AuditInfo = AuditInfoFactory.FromEntity(e)
        };

        private static string Normalizar(string texto) =>
            string.Concat(
                texto.Trim().ToLowerInvariant()
                    .Normalize(System.Text.NormalizationForm.FormD)
                    .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                        != System.Globalization.UnicodeCategory.NonSpacingMark)
            );
    }
}
