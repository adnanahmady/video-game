using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;

namespace VideoGame.Application.Modules.Auth.Services;

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
