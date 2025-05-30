using VideoGame.Domain.Interfaces.Repositories;

namespace VideoGame.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGameRepository Games { get; }
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    Task<int> CommitAsync();
}
