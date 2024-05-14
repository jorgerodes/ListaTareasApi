using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace ListaTareasApi.Infrastructure.Repositories;

public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId : class
{

    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    protected DbSet<TEntity> DbSet => _dbSet;
    protected ApplicationDbContext DbContext => _context;
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id);
    }

    public async void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
}
