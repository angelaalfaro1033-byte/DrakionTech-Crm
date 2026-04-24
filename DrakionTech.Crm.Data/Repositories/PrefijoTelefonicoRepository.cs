using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class PrefijoTelefonicoRepository
        : GenericRepository<PrefijoTelefonico>, IPrefijoTelefonicoRepository
    {
        public PrefijoTelefonicoRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<PrefijoTelefonico>> GetByPaisIdAsync(int paisId, CancellationToken ct = default)
        {
            return await _context.PrefijosTelefonicos
                .Where(x => x.PaisId == paisId)
                .ToListAsync(ct);
        }

        public async Task<PrefijoTelefonico?> GetByPaisAsync(int paisId, CancellationToken ct = default)
        {
            return await _context.PrefijosTelefonicos
                .FirstOrDefaultAsync(x => x.PaisId == paisId, ct);
        }
    }
}