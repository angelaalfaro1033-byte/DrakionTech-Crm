using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class PaisRepository : GenericRepository<Pais>, IPaisRepository
    {
        private readonly ApplicationDbContext _context;

        public PaisRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pais>> ObtenerTodosAsync(
            CancellationToken ct = default)
        {
            return await _context.Paises
                .AsNoTracking()
                .OrderBy(p => p.Nombre)
                .ToListAsync(ct);
        }

        public async Task<Pais?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default)
        {
            return await _context.Paises
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }
    }
}