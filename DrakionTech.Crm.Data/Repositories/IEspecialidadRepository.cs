using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IEspecialidadRepository : IGenericRepository<Especialidad>
    {
        Task<List<Especialidad>> ObtenerTodosConRolAsync();
        Task<bool> ExisteEspecialidadEnRolAsync(int especialidadId, int rolUsuarioId);
    }
}