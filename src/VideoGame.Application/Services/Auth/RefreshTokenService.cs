using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Domain.Interfaces.Support.Auth;

namespace VideoGame.Application.Services.Auth;

public class RefreshTokenService(ITokenGenerator tokenGenerator) : IRefreshTokenService
{
    public async Task<TokenDto?> RefreshAsync(RefreshTokenDto dto)
    {
        var user = await tokenGenerator.ValidateRefreshTokenAsync(
            dto.UserId, dto.RefreshToken);

        if (user is null)
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
