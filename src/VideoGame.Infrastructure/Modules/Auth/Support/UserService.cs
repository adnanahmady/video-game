using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Support;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Infrastructure.Modules.Auth.Support;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    public async Task<User?> FindByIdAsync(Guid id) =>
        await unitOfWork.Users.FindByIdAsync(id);

    public async Task<string?> GetRoleAsync(User user)
    {
        if (user.RoleId == null)
            return null;

        var roleId = user.RoleId.GetValueOrDefault();
        var role = await unitOfWork.Roles.FindByIdAsync(roleId);
        return role?.Name;
    }
}
