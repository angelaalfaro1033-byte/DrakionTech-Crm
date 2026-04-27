using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public class RolUsuarioRepository : GenericRepository<RolUsuario>, IRolUsuarioRepository
    {
        public RolUsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}