using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class PropuestaRepository
        : GenericRepository<Propuesta>, IPropuestaRepository
    {
        public PropuestaRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<Propuesta?> ObtenerPorIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet
                .Include(p => p.CreatedByUser)
                .Include(p => p.ModifiedByUser)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task<IEnumerable<Propuesta>> ObtenerPorOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
            return await _dbSet
                .Include(p => p.CreatedByUser)
                .Include(p => p.ModifiedByUser)
                .Where(p => p.OportunidadId == oportunidadId)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
