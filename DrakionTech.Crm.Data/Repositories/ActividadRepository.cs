using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class ActividadRepository
        : GenericRepository<Actividad>, IActividadRepository
    {
        public ActividadRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Actividad>> GetByEmpresaIdAsync(
      int empresaId,
      CancellationToken ct = default)
        {
            return await _context.Actividades
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.UsuarioInterno)
                .Include(a => a.Empresa)
                .Include(a => a.Contacto)
                .Include(a => a.Oportunidad)
                .Where(a => a.EmpresaId == empresaId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> GetByOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
                return await _context.Actividades
        .Include(a => a.TipoActividad)
        .Include(a => a.EstadoActividad)
        .Include(a => a.UsuarioInterno)
        .Include(a => a.Empresa)
        .Include(a => a.Contacto)
        .Include(a => a.Oportunidad)
                .Where(a => a.OportunidadId == oportunidadId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<bool> HasOverlapAsync(
            int usuarioInternoId,
            DateTime inicio,
            DateTime fin,
            int? actividadIdExcluir = null,
            CancellationToken ct = default)
        {
            var query = _context.Actividades
                .Where(a =>
                    a.UsuarioInternoId == usuarioInternoId &&
                    a.EstadoActividad.Nombre != "Cancelada" &&
                    a.Inicio < fin &&
                    a.Fin > inicio);

            if (actividadIdExcluir.HasValue)
            {
                query = query.Where(a => a.Id != actividadIdExcluir.Value);
            }

            return await query.AnyAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> GetUpcomingAsync(
            DateTime desde,
            CancellationToken ct = default)
        {
            return await _context.Actividades
                .Where(a =>
                    a.Inicio >= desde &&
                    a.EstadoActividad.Id != SeedIds.EstadoActividadCancelada)
                .AsNoTracking()
                .OrderBy(a => a.Inicio)
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> GetCalendarRangeAsync(
            DateTime inicio,
            DateTime fin,
            int? usuarioInternoId = null,
            CancellationToken ct = default)
        {
            var query = _context.Actividades
                .Where(a =>
                    a.Inicio < fin &&
                    a.Fin > inicio &&
                    a.EstadoActividad.Id != SeedIds.EstadoActividadCancelada);

            if (usuarioInternoId.HasValue)
            {
                query = query.Where(a =>
                    a.UsuarioInternoId == usuarioInternoId.Value);
            }

            return await query
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> GetByUsuarioAsync(
            int usuarioInternoId,
            CancellationToken ct = default)
        {
            return await _context.Actividades
                .Where(a => a.UsuarioInternoId == usuarioInternoId)
                .AsNoTracking()
                .OrderBy(a => a.Inicio)
                .ToListAsync(ct);
        }
    }
}