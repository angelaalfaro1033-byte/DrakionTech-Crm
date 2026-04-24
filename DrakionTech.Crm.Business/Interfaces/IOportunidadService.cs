using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Business.DTOs.Oportunidad;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IOportunidadService
    {
        Task<int> CrearAsync(CrearOportunidadDto dto, CancellationToken ct = default);

        Task ActualizarAsync(int oportunidadId, ActualizarOportunidadDto dto, CancellationToken ct = default);

        Task<OportunidadDto> ObtenerPorIdAsync(int oportunidadId, CancellationToken ct = default);

        Task<IEnumerable<OportunidadDto>> ObtenerPorEmpresaAsync(int empresaId, CancellationToken ct = default);

        Task CambiarEtapaAsync(int oportunidadId, EtapaOportunidad nuevaEtapa, CancellationToken ct = default);

        IEnumerable<OpcionEnumDto> ObtenerEtapas();
    }
}