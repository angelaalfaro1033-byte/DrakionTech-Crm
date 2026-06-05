using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class EmpresaRepository
        : GenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpresaRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<Empresa> Query()
        {
            return _context.Empresas
                .Include(e => e.Pais)
                .Include(e => e.Ciudad)
                .Include(e => e.SectorEmpresa)
                .Include(e => e.SubsectorEmpresa)
                .AsQueryable();
        }

        // HEADER / DETALLE DE EMPRESA
        public async Task<Empresa?> ObtenerConUbicacionAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            return await _context.Empresas
                .AsNoTracking()
                .Include(e => e.Pais)
                .Include(e => e.Ciudad)
                .Include(e => e.Correos)
                .Include(e => e.Contactos)
                .FirstOrDefaultAsync(e => e.Id == empresaId, ct);
        }

        // EDICIÓN (SIN RELACIONES PESADAS)
        public async Task<Empresa?> ObtenerParaEdicionAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            return await _context.Empresas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == empresaId, ct);
        }

        // VALIDACIONES
        public async Task<bool> ExisteAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            return await _context.Empresas
                .AsNoTracking()
                .AnyAsync(e => e.Id == empresaId, ct);
        }

        public async Task<List<Empresa>> ObtenerTodasConRelacionesAsync(CancellationToken ct = default)
        {
            return await _context.Empresas
                .AsNoTracking()
                .Include(e => e.Pais)
                .Include(e => e.Ciudad)
                .Include(e => e.SectorEmpresa)
                .Include(e => e.SubsectorEmpresa)
                .ToListAsync(ct);
        }
    }
}