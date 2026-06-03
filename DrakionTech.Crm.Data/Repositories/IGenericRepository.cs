namespace DrakionTech.Crm.Data.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query();
        Task<TEntity?> ObtenerPorIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> ObtenerTodosAsync(CancellationToken ct = default);
        Task AgregarAsync(TEntity entity, CancellationToken ct = default);
        Task ActualizarAsync(TEntity entity, CancellationToken ct = default);
        Task EliminarAsync(int id, CancellationToken ct = default);
        Task<bool> ExisteAsync(int id, CancellationToken ct = default);
    }
}