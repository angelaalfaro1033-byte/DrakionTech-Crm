using DrakionTech.Crm.Business.DTOs.Empleado;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoListDto>> ObtenerTodosAsync();
        Task CrearAsync(CrearEmpleadoDto dto);
        Task EditarAsync(ActualizarEmpleadoDto dto);
        Task DesactivarAsync(int id);
        Task<EmpleadoListDto> ObtenerPorIdAsync(int id);
    }
}