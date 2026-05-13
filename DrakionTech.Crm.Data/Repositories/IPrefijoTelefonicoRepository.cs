using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IPrefijoTelefonicoRepository : IGenericRepository<PrefijoTelefonico>
    {
        Task<IEnumerable<PrefijoTelefonico>> ObtenerPorPaisIdAsync(int paisId, CancellationToken ct = default);
        Task<PrefijoTelefonico?> ObtenerPorPaisAsync(int paisId, CancellationToken ct = default);
    }
}