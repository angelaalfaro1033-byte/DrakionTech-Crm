using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public class TipoActividadRepository
        : GenericRepository<TipoActividad>, ITipoActividadRepository
    {
        public TipoActividadRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}