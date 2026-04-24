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

        public async Task<IEnumerable<Propuesta>> GetByOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
            return await _dbSet
                .Where(p => p.OportunidadId == oportunidadId)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}