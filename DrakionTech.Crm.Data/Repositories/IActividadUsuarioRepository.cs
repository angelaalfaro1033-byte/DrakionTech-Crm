using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IActividadUsuarioRepository
    {
        Task AddRangeAsync(
            IEnumerable<ActividadUsuario> entidades,
            CancellationToken ct = default);

        Task RemoveByActividadIdAsync(
            int actividadId,
            CancellationToken ct = default);
    }

}