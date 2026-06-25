using DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IEmpleadoProyectoAsignacionService
{
    Task<List<AsignacionProyectoListDto>> ObtenerTodosAsync(int? empleadoId = null, int? proyectoId = null, bool? soloActivas = null);
    Task<List<ReporteAsignacionProyectoDto>> ObtenerSinAsignacionAsync();
    Task<List<ReporteAsignacionProyectoDto>> ObtenerMultiplesProyectosAsync();
    Task<List<ReporteAsignacionProyectoDto>> ObtenerDistribucionCargaAsync();
    Task<AsignacionProyectoListDto> ObtenerPorIdAsync(int id);
    Task CrearAsync(CrearAsignacionProyectoDto dto);
    Task ActualizarAsync(ActualizarAsignacionProyectoDto dto);
    Task FinalizarAsync(int id, DateTime? fechaFin = null);
    Task ReactivarAsync(int id);
}
