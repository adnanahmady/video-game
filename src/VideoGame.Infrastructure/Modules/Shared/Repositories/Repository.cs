using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Shared.Interfaces;
using VideoGame.Domain.Modules.Shared.Interfaces.Repositories;

namespace VideoGame.Infrastructure.Modules.Shared.Repositories;

public abstract class Repository<TEntity, TId>(DbContext context) : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId> where TId : notnull
{
    protected readonly DbContext Context = context;

    public async Task<TEntity?> FindByIdAsync(TId id) => await Context
        .Set<TEntity>().OrderBy(e => e.Id)
        .SingleOrDefaultAsync(e => e.Id.Equals(id));

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Context.Set<TEntity>().OrderBy(e => e.Id)
            .SingleOrDefaultAsync(predicate);

    public async Task<ICollection<TEntity>> GetPaginatedAsync(int page, int pageSize) =>
        await Context.Set<TEntity>()
            .OrderBy(g => g.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task<int> CountAsync() => await Context.Set<TEntity>().CountAsync();

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Context.Set<TEntity>().AnyAsync(predicate);

    public async Task AddAsync(TEntity entity) =>
        await Context.Set<TEntity>().AddAsync(entity);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
        await Context.Set<TEntity>().AddRangeAsync(entities);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    public void Remove(TId id)
    {
        var entity = Context.Set<TEntity>().SingleOrDefault(e => e.Id.Equals(id));

        if (entity is null)
        {
            return;
        }

        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        Context.Set<TEntity>().RemoveRange(entities);
}
