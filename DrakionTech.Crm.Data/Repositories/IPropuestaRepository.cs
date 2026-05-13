using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IPropuestaRepository : IGenericRepository<Propuesta>
    {
        Task<IEnumerable<Propuesta>> ObtenerPorOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default);
    }
}