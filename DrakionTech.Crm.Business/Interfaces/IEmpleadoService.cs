using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empleado;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEmpleadoService
    {
        Task<ResultadoPaginacion<EmpleadoListDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null, int pagina = 1, int tamañoPagina = 10);
        Task<List<EmpleadoListDto>> ObtenerTodosSinPaginacionAsync();
        Task CrearAsync(CrearEmpleadoDto dto);
        Task EditarAsync(ActualizarEmpleadoDto dto);
        Task DesactivarAsync(int id);
        Task ActivarAsync(int id);
        Task<EmpleadoListDto> ObtenerPorIdAsync(int id);
        Task<EmpleadoListDto?> ObtenerPorEmailAsync(string email);
    }
}