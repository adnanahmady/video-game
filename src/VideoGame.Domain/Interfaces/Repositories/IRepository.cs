using System.Linq.Expressions;

namespace VideoGame.Domain.Interfaces.Repositories;

public interface IRepository<TEntity, in TId>
    where TEntity : class,
    IEntity<TId> where TId : notnull
{
    Task<TEntity?> FindByIdAsync(TId id);

    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task<ICollection<TEntity>> GetPaginatedAsync(int page, int pageSize);

    Task<int> CountAsync();

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);
    void Remove(TId id);

    void RemoveRange(IEnumerable<TEntity> entities);
}
