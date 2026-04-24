using DrakionTech.Crm.Business.DTOs.Catalogo;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<CatalogoDto>> ObtenerPaisesAsync(CancellationToken ct = default);
        Task<IEnumerable<CatalogoDto>> ObtenerCiudadesPorPaisAsync(int paisId, CancellationToken ct = default);

        Task<IEnumerable<CatalogoDto>> ObtenerSectoresAsync(CancellationToken ct = default);
        Task<IEnumerable<CatalogoDto>> ObtenerEstadosAsync(CancellationToken ct = default);
    }
}