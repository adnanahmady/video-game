using VideoGame.Api.Infrastructure.Repositories;

namespace VideoGame.Api.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IGameRepository Games { get; }
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    Task<int> CommitAsync();
}
