using ListaTareasApi.Domain.Abstractions;
using System.Linq.Expressions;


namespace ListaTareasApi.Domain.Abstractions
{
    public interface IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    {
        Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<int> SaveChangesAsync();

    }
}
