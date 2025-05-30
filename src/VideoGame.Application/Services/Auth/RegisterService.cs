using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces;
using VideoGame.Domain.Interfaces.Support.Hasher;

namespace VideoGame.Application.Services.Auth;

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
