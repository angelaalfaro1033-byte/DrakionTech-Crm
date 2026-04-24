using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
    }
}