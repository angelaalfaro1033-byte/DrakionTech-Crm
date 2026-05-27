using DrakionTech.Crm.Business.DTOs.Empleado;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoListDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null);
        Task CrearAsync(CrearEmpleadoDto dto);
        Task EditarAsync(ActualizarEmpleadoDto dto);
        Task DesactivarAsync(int id);
        Task ActivarAsync(int id);
        Task<EmpleadoListDto> ObtenerPorIdAsync(int id);
        Task<EmpleadoListDto?> ObtenerPorEmailAsync(string email);
    }
}