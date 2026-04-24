using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface ICiudadRepository : IGenericRepository<Ciudad>
    {
        Task<IEnumerable<Ciudad>> ObtenerPorPaisAsync(
            int paisId,
            CancellationToken ct = default
        );

        Task<Ciudad?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default
        );
    }
}