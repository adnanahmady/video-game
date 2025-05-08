using VideoGame.Api.Core.Dtos;
using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Infrastructure.Services.Auth;

public interface IRefreshTokenService
{
    Task<TokenResponseDto?> RefreshAsync(RefreshTokenForm form);
}
