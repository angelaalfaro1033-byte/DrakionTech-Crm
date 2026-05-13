using DrakionTech.Crm.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> ObtenerPorIdAsync(
            int id,
            CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodosAsync(
            CancellationToken ct = default)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task AgregarAsync(TEntity entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(TEntity entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(int id, CancellationToken ct = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, ct);
            if (entity is null)
                return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<bool> ExisteAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.AnyAsync(
                e => EF.Property<int>(e, "Id") == id,
                ct
            );
        }
    }
}