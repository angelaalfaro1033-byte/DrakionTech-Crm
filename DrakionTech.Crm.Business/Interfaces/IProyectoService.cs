using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Proyecto;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IProyectoService
{
    Task<List<ProyectoDto>> ObtenerTodosAsync();
    Task<ResultadoPaginacion<ProyectoDto>> ObtenerTodosConPaginacionAsync(string? busqueda = null, int pagina = 1, int tamañoPagina = 10);
    Task<ProyectoDto?> ObtenerPorIdAsync(int id);
    Task CrearAsync(CrearProyectoDto dto);
    Task ActualizarAsync(ActualizarProyectoDto dto);
    Task EliminarAsync(int id);
}