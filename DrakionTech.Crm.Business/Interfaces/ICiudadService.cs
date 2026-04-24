using DrakionTech.Crm.Business.DTOs.Ubicacion;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface ICiudadService
    {
        Task<IEnumerable<CiudadDto>> ObtenerPorPaisAsync(
            int paisId,
            CancellationToken ct = default);
    }
}