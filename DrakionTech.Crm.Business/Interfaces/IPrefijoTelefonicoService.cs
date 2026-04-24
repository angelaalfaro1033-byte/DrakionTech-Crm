using DrakionTech.Crm.Business.DTOs.PrefijoTelefonico;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IPrefijoTelefonicoService
    {
        Task<IEnumerable<PrefijoTelefonicoDto>> ObtenerTodosAsync(CancellationToken ct = default);
        Task<IEnumerable<PrefijoTelefonicoDto>> ObtenerPorPaisAsync(int paisId, CancellationToken ct = default);
        Task<PrefijoTelefonicoDto?> ObtenerPorPaisUnicoAsync(int paisId, CancellationToken ct = default);
        Task<string?> ObtenerCodigoPorPaisAsync(int paisId, CancellationToken ct = default);
    }
}