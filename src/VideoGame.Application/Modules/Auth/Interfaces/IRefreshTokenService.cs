using VideoGame.Application.Modules.Auth.Dtos;

namespace VideoGame.Application.Modules.Auth.Interfaces;

public interface IRefreshTokenService
{
    Task<TokenDto?> RefreshAsync(RefreshTokenDto dto);
}
