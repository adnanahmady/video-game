using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Auth.Services;

public class RegisterService(IUnitOfWork unitOfWork,
    IPasswordHasher hasher) : IRegisterService
{
    public async Task<RegisteredUserDto?> RegisterAsync(UserDto dto)
    {
        if (await unitOfWork.Users.AnyAsync(u => u.Username == dto.Username))
        {
            return null;
        }

        var user = new User();
        var hashedPassword = hasher.Hash(user, dto.Password);

        if (hashedPassword is null)
        {
            return null;
        }

        user.Username = dto.Username;
        user.PasswordHash = hashedPassword;
        user.Role = await unitOfWork.Roles.FindAsync(r => r.Name == "User");

        await unitOfWork.Users.AddAsync(user);
        await unitOfWork.CommitAsync();

        return new()
        {
            Id = user.Id,
            Username = user.Username
        };
    }
}
