using DrakionTech.Crm.Business.DTOs.Actividad;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IActividadService
    {
        Task<int> CrearAsync(CrearActividadDto dto, CancellationToken ct = default);
        Task<IEnumerable<TipoActividadDto>> ObtenerTiposActividadAsync(
    CancellationToken ct = default);

        Task ActualizarAsync(int actividadId, ActualizarActividadDto dto, CancellationToken ct = default);

        Task<ActividadDto> ObtenerPorIdAsync(int actividadId, CancellationToken ct = default);

        Task<IEnumerable<ActividadDto>> ObtenerPorEmpresaAsync(int empresaId, CancellationToken ct = default);

        Task<IEnumerable<ActividadDto>> ObtenerPorOportunidadAsync(int oportunidadId, CancellationToken ct = default);
    }
}