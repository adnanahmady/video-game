using VideoGame.Application.Modules.Auth.Dtos;

namespace VideoGame.Application.Modules.Auth.Interfaces;

public interface ILoginService
{
    Task<TokenDto?> LoginAsync(UserDto dto);
}
