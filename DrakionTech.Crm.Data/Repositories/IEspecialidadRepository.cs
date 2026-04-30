using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IEspecialidadRepository : IGenericRepository<Especialidad>
    {
        Task<List<Especialidad>> GetAllWithRolAsync();
    }
}