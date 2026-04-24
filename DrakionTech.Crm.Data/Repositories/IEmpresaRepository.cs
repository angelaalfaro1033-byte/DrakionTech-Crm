using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories
{
    public interface IEmpresaRepository : IGenericRepository<Empresa>
    {
        // Header / detalle simple
        Task<Empresa?> ObtenerConUbicacionAsync(
            int empresaId,
            CancellationToken ct = default);

        // Edición
        Task<Empresa?> ObtenerParaEdicionAsync(
            int empresaId,
            CancellationToken ct = default);

        Task<List<Empresa>> ObtenerTodasConRelacionesAsync(
        CancellationToken ct = default);
    }
}