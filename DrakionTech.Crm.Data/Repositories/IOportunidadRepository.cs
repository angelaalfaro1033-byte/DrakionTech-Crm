using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IOportunidadRepository : IGenericRepository<Oportunidad>
    {
        Task<IEnumerable<Oportunidad>> ObtenerPorEmpresaIdAsync(
            int empresaId,
            CancellationToken ct = default);
    }
}