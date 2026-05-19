using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IActividadRepository : IGenericRepository<Actividad>
    {
        Task<IEnumerable<Actividad>> ObtenerPorEmpresaIdAsync(
            int empresaId,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> ObtenerPorOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default);

        Task<bool> TieneSolapamientoAsync(
            int usuarioId,
            DateTime inicio,
            DateTime fin,
            int? actividadIdExcluir = null,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> ObtenerProximasAsync(
            DateTime desde,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> ObtenerPorRangoCalendarioAsync(
            DateTime inicio,
            DateTime fin,
            int? usuarioId = null,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> ObtenerPorUsuarioAsync(
            int usuarioId,
            CancellationToken ct = default);
        Task<IEnumerable<Actividad>> ObtenerDashboardPorUsuarioAsync(
              int usuarioId,
              CancellationToken ct = default);
        Task<IEnumerable<Actividad>> ObtenerCadenaAsync(
            int actividadId,
            CancellationToken ct = default);
    }
}