using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Especialidad;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null);
        Task<ResultadoPaginacion<EspecialidadDto>> ObtenerTodosConPaginacionAsync(string? busqueda = null, bool? soloActivos = null, int pagina = 1, int tamañoPagina = 10);
        Task<EspecialidadDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(EspecialidadDto dto);
        Task EditarAsync(EspecialidadDto dto);
        Task ActivarAsync(int id);
        Task DesactivarAsync(int id);
        Task<EspecialidadDto> CrearYObtenerAsync(string nombre, int rolUsuarioId);
    }
}