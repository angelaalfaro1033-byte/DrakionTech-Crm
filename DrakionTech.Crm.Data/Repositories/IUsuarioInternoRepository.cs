using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IUsuarioInternoRepository : IGenericRepository<UsuarioInterno>
    {
        Task<IEnumerable<UsuarioInterno>> GetActivosAsync(
            CancellationToken ct = default);

        Task<UsuarioInterno?> GetByEmailAsync(
            string email,
            CancellationToken ct = default);
    }
}