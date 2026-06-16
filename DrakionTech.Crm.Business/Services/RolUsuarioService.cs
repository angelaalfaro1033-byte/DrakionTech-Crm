using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.RolUsuario;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly ApplicationDbContext _db;

        public RolUsuarioService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResultadoPaginacion<RolUsuarioDto>> ObtenerTodosConPaginacionAsync(string? busqueda = null, bool? soloActivos = null, int pagina = 1, int tamañoPagina = 10)
        {
            var query = _db.RolesUsuario
                .Include(r => r.CreatedByUser)
                .Include(r => r.ModifiedByUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(r => r.Nombre.ToLower().Contains(term));
            }

            if (soloActivos.HasValue)
                query = query.Where(r => r.Activo == soloActivos.Value);

            return await query
                .OrderBy(r => r.Nombre)
                .Select(r => new RolUsuarioDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Activo = r.Activo,
                    AuditInfo = AuditInfoFactory.FromEntity(r)
                })
                .PaginarAsync(pagina, tamañoPagina);
        }

        public async Task<List<RolUsuarioDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null)
        {
            var query = _db.RolesUsuario
                .Include(r => r.CreatedByUser)
                .Include(r => r.ModifiedByUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(r => r.Nombre.ToLower().Contains(term));
            }

            if (soloActivos.HasValue)
                query = query.Where(r => r.Activo == soloActivos.Value);

            return await query
                .OrderBy(r => r.Nombre)
                .Select(r => new RolUsuarioDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Activo = r.Activo,
                    AuditInfo = AuditInfoFactory.FromEntity(r)
                })
                .ToListAsync();
        }

        public async Task<RolUsuarioDto> ObtenerPorIdAsync(int id)
        {
            var rol = await _db.RolesUsuario
                .Include(r => r.CreatedByUser)
                .Include(r => r.ModifiedByUser)
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            return MapToDto(rol);
        }

        public async Task CrearAsync(RolUsuarioDto dto)
        {
            var rol = new RolUsuario
            {
                Nombre = dto.Nombre.Trim(),
                Activo = true
            };
            _db.RolesUsuario.Add(rol);
            await _db.SaveChangesAsync();
        }

        public async Task EditarAsync(RolUsuarioDto dto)
        {
            var rol = await _db.RolesUsuario.FindAsync(dto.Id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            rol.Nombre = dto.Nombre.Trim();
            rol.Activo = dto.Activo;
            await _db.SaveChangesAsync();
        }

        public async Task DesactivarAsync(int id)
        {
            var rol = await _db.RolesUsuario.FindAsync(id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            rol.Activo = false;
            await _db.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var rol = await _db.RolesUsuario.FindAsync(id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            rol.Activo = true;
            await _db.SaveChangesAsync();
        }

        public async Task<RolUsuarioDto> CrearYObtenerAsync(string nombre)
        {
            var normalizado = Normalizar(nombre);
            var existente = await _db.RolesUsuario
                .FirstOrDefaultAsync(r => r.Nombre.ToLower() == normalizado);

            if (existente is not null)
                return MapToDto(existente);

            var nuevo = new RolUsuario { Nombre = nombre.Trim(), Activo = true };
            _db.RolesUsuario.Add(nuevo);
            await _db.SaveChangesAsync();
            return MapToDto(nuevo);
        }

        private static RolUsuarioDto MapToDto(RolUsuario r) => new()
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Activo = r.Activo,
            AuditInfo = AuditInfoFactory.FromEntity(r)
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
