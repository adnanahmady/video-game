using VideoGame.Api.Core.Dtos;
using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Application.Services.Auth;

public class RefreshTokenService(ITokenGenerator tokenGenerator) : IRefreshTokenService
{
    public async Task<TokenResponseDto?> RefreshAsync(RefreshTokenForm form)
    {
        var user = await tokenGenerator.ValidateRefreshTokenAsync(
            form.UserId, form.RefreshToken);

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
