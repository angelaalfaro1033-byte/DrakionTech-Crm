using DrakionTech.Crm.Business.DTOs.Ubicacion;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDto>> ObtenerTodosAsync(
            CancellationToken ct = default);
    }
}