using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public class RolContactoRepository : GenericRepository<RolContacto>, IRolContactoRepository
    {
        public RolContactoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}