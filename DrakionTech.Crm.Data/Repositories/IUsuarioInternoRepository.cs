using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IUsuarioInternoRepository : IGenericRepository<UsuarioInterno>
    {
        Task<IEnumerable<UsuarioInterno>> ObtenerActivosAsync(
            CancellationToken ct = default);

        Task<UsuarioInterno?> ObtenerPorEmailAsync(
            string email,
            CancellationToken ct = default);
    }
}