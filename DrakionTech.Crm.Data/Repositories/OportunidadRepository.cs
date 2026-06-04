using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class OportunidadRepository
        : GenericRepository<Oportunidad>, IOportunidadRepository
    {
        public OportunidadRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<Oportunidad?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default)
        {
            return await _context.Oportunidades
                .Include(o => o.Empresa)
                .Include(o => o.ContactoPrincipal)
                .Include(o => o.Proyectos)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id, ct);
        }

        public async Task<IEnumerable<Oportunidad>> ObtenerPorEmpresaIdAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            return await _context.Oportunidades
                .Where(o => o.EmpresaId == empresaId)
                .Include(o => o.Empresa)
                .Include(o => o.ContactoPrincipal)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Oportunidad>> ObtenerTodosAsync(
            CancellationToken ct = default)
        {
            return await _context.Oportunidades
                .Include(o => o.Empresa)
                .Include(o => o.ContactoPrincipal)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}