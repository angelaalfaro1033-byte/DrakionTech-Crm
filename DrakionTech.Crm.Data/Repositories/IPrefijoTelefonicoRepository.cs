using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IPrefijoTelefonicoRepository : IGenericRepository<PrefijoTelefonico>
    {
        Task<IEnumerable<PrefijoTelefonico>> GetByPaisIdAsync(int paisId, CancellationToken ct = default);
        Task<PrefijoTelefonico?> GetByPaisAsync(int paisId, CancellationToken ct = default);
    }
}