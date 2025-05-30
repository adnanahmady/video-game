using VideoGame.Application.Dtos.Auth;

namespace VideoGame.Application.Interfaces.Services.Auth;

public interface IRegisterService
{
    Task<RegisteredUserDto?> RegisterAsync(UserDto form);
}
