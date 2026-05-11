using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IActividadRepository : IGenericRepository<Actividad>
    {
        Task<IEnumerable<Actividad>> GetByEmpresaIdAsync(
            int empresaId,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> GetByOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default);

        Task<bool> HasOverlapAsync(
            int usuarioId,
            DateTime inicio,
            DateTime fin,
            int? actividadIdExcluir = null,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> GetUpcomingAsync(
            DateTime desde,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> GetCalendarRangeAsync(
            DateTime inicio,
            DateTime fin,
            int? usuarioId = null,
            CancellationToken ct = default);

        Task<IEnumerable<Actividad>> GetByUsuarioAsync(
            int usuarioId,
            CancellationToken ct = default);
        Task<IEnumerable<Actividad>> GetDashboardByUsuarioAsync(
              int usuarioId,
              CancellationToken ct = default);
    }
}