using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        private readonly ApplicationDbContext _context;

        public CiudadRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ciudad>> ObtenerPorPaisAsync(
            int paisId,
            CancellationToken ct = default)
        {
            return await _context.Ciudades
                .AsNoTracking()
                .Where(c => c.PaisId == paisId)
                .OrderBy(c => c.Nombre)
                .ToListAsync(ct);
        }

        public async Task<Ciudad?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default)
        {
            return await _context.Ciudades
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }
    }
}