using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public class SectorRepository : GenericRepository<Sector>, ISectorRepository
    {
        public SectorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}