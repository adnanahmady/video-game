using VideoGame.Domain.Interfaces;
using VideoGame.Domain.Interfaces.Repositories;
using VideoGame.Infrastructure.Repositories;

namespace VideoGame.Infrastructure;

public class UnitOfWork(VideoGameDbContext context) : IUnitOfWork
{
    public IGameRepository Games { get; } = new GameRepository(context);
    public IUserRepository Users { get; } = new UserRepository(context);
    public IRoleRepository Roles { get; } = new RoleRepository(context);

    public async Task<int> CommitAsync() => await context.SaveChangesAsync();

    public void Dispose() => context.Dispose();
}
