using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces.Repositories;

namespace VideoGame.Domain.Modules.Auth.Interfaces.Repositories;

public interface IPermissionRepository : IRepository<Permission, int>
{
    Task<Permission> FirstOrCreateByNameAsync(
        string name,
        Func<string, Permission>? fn = null);
}
