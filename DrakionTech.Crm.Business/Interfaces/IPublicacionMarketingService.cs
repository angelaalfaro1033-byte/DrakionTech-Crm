using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Marketing;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IPublicacionMarketingService
{
    Task<List<PublicacionMarketingDto>> ObtenerTodosAsync();

    Task<ResultadoPaginacion<PublicacionMarketingDto>> ObtenerTodosConPaginacionAsync(
        string? busqueda = null,
        int pagina = 1,
        int tamañoPagina = 10);

    Task<PublicacionMarketingDto?> ObtenerPorIdAsync(int id);

    Task CrearAsync(CrearPublicacionMarketingDto dto);

    Task ActualizarAsync(ActualizarPublicacionMarketingDto dto);

    Task EliminarAsync(int id);

    Task<List<MetricaPublicacionDto>> ObtenerMetricasAsync();

    Task CrearMetricaAsync(CrearMetricaPublicacionDto dto);
}