using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class EspecialidadRepository : GenericRepository<Especialidad>, IEspecialidadRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Especialidad>> GetAllWithRolAsync()
        {
            return await _context.Especialidades
                .Include(e => e.RolUsuario)
                .ToListAsync();
        }
    }
}