using VideoGame.Domain.Modules.Auth.Interfaces.Repositories;
using VideoGame.Domain.Modules.Games.Interfaces.Repositories;
using VideoGame.Domain.Modules.Shared.Interfaces;
using VideoGame.Infrastructure.Modules.Auth.Repositories;
using VideoGame.Infrastructure.Modules.Games.Repositories;

namespace VideoGame.Infrastructure.Modules.Shared;

public class UnitOfWork(VideoGameDbContext context) : IUnitOfWork
{
    public IGameRepository Games { get; } = new GameRepository(context);
    public IUserRepository Users { get; } = new UserRepository(context);
    public IRoleRepository Roles { get; } = new RoleRepository(context);

    public async Task<int> CommitAsync() => await context.SaveChangesAsync();

    public void Dispose() => context.Dispose();
}
