using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IPaisRepository : IGenericRepository<Pais>
    {
        Task<IEnumerable<Pais>> ObtenerTodosAsync(
            CancellationToken ct = default
        );

        Task<Pais?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default
        );
    }
}