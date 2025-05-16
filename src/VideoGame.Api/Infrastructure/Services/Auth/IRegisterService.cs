using VideoGame.Api.Core.Dtos.Auth;
using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Infrastructure.Services.Auth;

public interface IRegisterService
{
    Task<RegisteredUserDto?> RegisterAsync(UserForm form);
}
