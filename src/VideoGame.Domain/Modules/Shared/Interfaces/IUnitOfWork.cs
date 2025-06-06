using VideoGame.Domain.Modules.Auth.Interfaces.Repositories;
using VideoGame.Domain.Modules.Games.Interfaces.Repositories;

namespace VideoGame.Domain.Modules.Shared.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGameRepository Games { get; }
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }

    Task<int> CommitAsync();
}
