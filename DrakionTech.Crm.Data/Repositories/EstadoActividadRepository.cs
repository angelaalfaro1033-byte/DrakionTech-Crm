using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public class EstadoActividadRepository
        : GenericRepository<EstadoActividad>, IEstadoActividadRepository
    {
        public EstadoActividadRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}