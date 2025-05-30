using VideoGame.Application.Dtos.Auth;

namespace VideoGame.Application.Interfaces.Services.Auth;

public interface IRefreshTokenService
{
    Task<TokenDto?> RefreshAsync(RefreshTokenDto dto);
}
