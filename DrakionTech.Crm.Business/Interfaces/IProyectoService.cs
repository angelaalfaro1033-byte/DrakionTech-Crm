using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Proyecto;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IProyectoService
{
    Task<List<ProyectoDto>> ObtenerTodosAsync();
    Task<ResultadoPaginacion<ProyectoDto>> ObtenerTodosConPaginacionAsync(string? busqueda = null, int pagina = 1, int tamañoPagina = 10);
    Task<ProyectoDto?> ObtenerPorIdAsync(int id);
    Task CrearAsync(CrearProyectoDto dto);
    Task ActualizarAsync(ActualizarProyectoDto dto);
    Task EliminarAsync(int id);
    Task CambiarEtapaAsync(CambiarEtapaProyectoDto dto);
    Task AgregarPagoAsync(int proyectoId, PagoProyectoDto dto);
    Task ActualizarPagoAsync(int proyectoId, PagoProyectoDto dto);
    Task EliminarPagoAsync(int proyectoId, int pagoId);
    EtapaFlujoProyecto? ObtenerSiguienteEtapa(EtapaFlujoProyecto actual); // agregar esto
}
