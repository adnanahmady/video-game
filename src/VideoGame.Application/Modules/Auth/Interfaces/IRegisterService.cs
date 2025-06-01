using VideoGame.Application.Modules.Auth.Dtos;

namespace VideoGame.Application.Modules.Auth.Interfaces;

public interface IRegisterService
{
    Task<RegisteredUserDto?> RegisterAsync(UserDto form);
}
