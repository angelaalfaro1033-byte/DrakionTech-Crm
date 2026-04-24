using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IPropuestaRepository : IGenericRepository<Propuesta>
    {
        Task<IEnumerable<Propuesta>> GetByOportunidadIdAsync(
            int oportunidadId,
            CancellationToken ct = default);
    }
}