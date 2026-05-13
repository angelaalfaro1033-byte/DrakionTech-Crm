using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> ObtenerTodosAsync();
        Task<Empleado?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Empleado empleado);
        Task ActualizarAsync(Empleado empleado);
    }
}