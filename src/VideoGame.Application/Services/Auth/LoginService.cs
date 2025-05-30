using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Domain.Interfaces;
using VideoGame.Domain.Interfaces.Support.Auth;
using VideoGame.Domain.Interfaces.Support.Hasher;

namespace VideoGame.Application.Services.Auth;

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
