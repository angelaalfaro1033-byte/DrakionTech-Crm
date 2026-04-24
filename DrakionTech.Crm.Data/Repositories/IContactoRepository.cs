using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IContactoRepository : IGenericRepository<Contacto>
    {
        Task<IEnumerable<Contacto>> GetByEmpresaIdAsync(
            int empresaId,
            CancellationToken ct = default);
    }
}