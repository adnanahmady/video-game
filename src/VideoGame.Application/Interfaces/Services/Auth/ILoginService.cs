using VideoGame.Application.Dtos.Auth;

namespace VideoGame.Application.Interfaces.Services.Auth;

public interface ILoginService
{
    Task<TokenDto?> LoginAsync(UserDto dto);
}
