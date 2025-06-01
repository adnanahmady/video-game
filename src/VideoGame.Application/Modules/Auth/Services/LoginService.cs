using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Auth.Services;

public class LoginService(
    IUnitOfWork unitOfWork,
    ITokenGenerator tokenGenerator,
    IPasswordHasher hasher) : ILoginService
{
    public async Task<TokenDto?> LoginAsync(UserDto dto)
    {
        var user = await unitOfWork.Users.GetUserWithRoleAsync(dto.Username);

        if (user is null)
        {
            return null;
        }

        var isVerified = hasher.Verify(user, user.PasswordHash, dto.Password);

        if (!isVerified)
        {
            return null;
        }

        return new()
        {
            AccessToken = tokenGenerator.CreateToken(user),
            RefreshToken = await tokenGenerator.GenerateRefreshTokenAsync(user)
        };
    }
}
