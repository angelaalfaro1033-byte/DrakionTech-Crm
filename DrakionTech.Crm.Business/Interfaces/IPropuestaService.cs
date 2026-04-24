using DrakionTech.Crm.Business.DTOs.Propuesta;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IPropuestaService
    {
        Task<int> CrearAsync(CrearPropuestaDto dto, CancellationToken ct = default);

        Task<IEnumerable<PropuestaDto>> ObtenerPorOportunidadAsync(int oportunidadId, CancellationToken ct = default);
    }
}