using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class UsuarioInternoRepository
        : GenericRepository<UsuarioInterno>, IUsuarioInternoRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioInternoRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioInterno>> GetActivosAsync(
            CancellationToken ct = default)
        {
            return await _context.UsuariosInternos
                .Where(u => u.Activo)
                .OrderBy(u => u.Nombre)
                .ToListAsync(ct);
        }

        public async Task<UsuarioInterno?> GetByEmailAsync(
            string email,
            CancellationToken ct = default)
        {
            return await _context.UsuariosInternos
                .FirstOrDefaultAsync(u => u.Email == email, ct);
        }
    }
}