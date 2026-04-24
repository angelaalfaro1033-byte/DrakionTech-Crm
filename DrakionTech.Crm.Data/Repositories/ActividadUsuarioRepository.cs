using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class ActividadUsuarioRepository : IActividadUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public ActividadUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(
            IEnumerable<ActividadUsuario> entidades,
            CancellationToken ct = default)
        {
            await _context.ActividadUsuarios.AddRangeAsync(entidades, ct);
        }

        public async Task RemoveByActividadIdAsync(
            int actividadId,
            CancellationToken ct = default)
        {
            var existentes = await _context.ActividadUsuarios
                .Where(x => x.ActividadId == actividadId)
                .ToListAsync(ct);

            _context.ActividadUsuarios.RemoveRange(existentes);
        }
    }
}