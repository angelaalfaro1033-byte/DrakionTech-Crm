using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class ContactoRepository
        : GenericRepository<Contacto>, IContactoRepository
    {
        public ContactoRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<Contacto?> ObtenerPorIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet
                .Include(c => c.Empresa)
                .Include(c => c.RolContacto)
                .Include(c => c.CreatedByUser)
                .Include(c => c.ModifiedByUser)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<IEnumerable<Contacto>> GetByEmpresaIdAsync(int empresaId, CancellationToken ct = default)
        {
            return await _dbSet
                .Include(c => c.Empresa)
                .Include(c => c.RolContacto)
                .Include(c => c.CreatedByUser)
                .Include(c => c.ModifiedByUser)
                .Where(c => c.EmpresaId == empresaId)
                .ToListAsync(ct);
        }
    }
}
