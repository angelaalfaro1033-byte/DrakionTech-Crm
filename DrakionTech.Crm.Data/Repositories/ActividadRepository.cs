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

        public async Task<IEnumerable<Actividad>> ObtenerPorEmpresaIdAsync(
    int empresaId,
    CancellationToken ct = default)
        {
            return await _context.Actividades
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.Usuario)
                .Include(a => a.Empresa)
                .Include(a => a.Contacto)
                .Include(a => a.Oportunidad)
                .Include(a => a.ActividadPrevia)          // ← agregar
                    .ThenInclude(p => p.TipoActividad)    // ← agregar
                .Where(a => a.EmpresaId == empresaId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
                return await _context.Actividades
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.Usuario)
                .Include(a => a.Empresa)
                .Include(a => a.Contacto)
                .Include(a => a.Oportunidad)
                .Where(a => a.OportunidadId == oportunidadId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<bool> TieneSolapamientoAsync(
            int usuarioId,
            DateTime inicio,
            DateTime fin,
            int? actividadIdExcluir = null,
            CancellationToken ct = default)
        {
            var query = _context.Actividades
                .Where(a =>
                    a.UsuarioId == usuarioId &&
                    a.EstadoActividad.Nombre != "Cancelada" &&
                    a.Inicio < fin &&
                    a.Fin > inicio);

            if (actividadIdExcluir.HasValue)
            {
                query = query.Where(a => a.Id != actividadIdExcluir.Value);
            }

            return await query.AnyAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> ObtenerProximasAsync(
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

        public async Task<IEnumerable<Actividad>> ObtenerPorRangoCalendarioAsync(
            DateTime inicio,
            DateTime fin,
            int? usuarioId = null,
            CancellationToken ct = default)
        {
            var query = _context.Actividades
                .Where(a =>
                    a.Inicio < fin &&
                    a.Fin > inicio &&
                    a.EstadoActividad.Id != SeedIds.EstadoActividadCancelada);

            if (usuarioId.HasValue)
            {
                query = query.Where(a =>
                    a.UsuarioId == usuarioId.Value);
            }

            return await query
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorUsuarioAsync(
            int usuarioId,
            CancellationToken ct = default)
        {
            return await _context.Actividades
                .Where(a => a.UsuarioId == usuarioId)
                .AsNoTracking()
                .OrderBy(a => a.Inicio)
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> ObtenerDashboardPorUsuarioAsync(
     int usuarioId,
     CancellationToken ct = default)
        {
            return await _context.Actividades
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.Empresa)
                .Include(a => a.Contacto)
                .Include(a => a.Oportunidad)
                .Include(a => a.ActividadPrevia)          // ← agregar
                    .ThenInclude(p => p.TipoActividad)    // ← agregar
                .Where(a =>
                    a.UsuarioId == usuarioId &&
                    a.EstadoActividad.Id != SeedIds.EstadoActividadCancelada)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Actividad>> ObtenerCadenaAsync(
            int actividadId,
            CancellationToken ct = default)
        {
            // Sube hasta la raíz de la cadena
            var todas = await _context.Actividades
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .AsNoTracking()
                .ToListAsync(ct);

            // Encuentra la raíz
            var actual = todas.FirstOrDefault(a => a.Id == actividadId);
            while (actual?.ActividadPreviaId != null)
                actual = todas.FirstOrDefault(a => a.Id == actual.ActividadPreviaId);

            if (actual == null) return [];

            // Construye la cadena hacia adelante
            var cadena = new List<Actividad>();
            var nodo = actual;
            while (nodo != null)
            {
                cadena.Add(nodo);
                nodo = todas.FirstOrDefault(a => a.ActividadPreviaId == nodo.Id);
            }

            return cadena;
        }
    }
}