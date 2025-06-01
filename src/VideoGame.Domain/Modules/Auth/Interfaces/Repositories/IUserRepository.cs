using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces.Repositories;

namespace VideoGame.Domain.Modules.Auth.Interfaces.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetUserWithRoleAsync(string username);
}
