using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Domain.Modules.Auth.Support;

public interface IUserService
{
    Task<User?> FindByIdAsync(Guid id);
    Task<string?> GetRoleAsync(User user);
}
