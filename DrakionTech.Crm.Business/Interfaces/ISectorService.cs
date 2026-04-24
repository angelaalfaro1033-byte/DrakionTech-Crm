using DrakionTech.Crm.Business.DTOs.Catalogo;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface ISectorService
    {
        Task<IEnumerable<CatalogoDto>> ObtenerTodosAsync(CancellationToken ct = default);
    }
}