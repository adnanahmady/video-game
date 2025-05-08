using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Infrastructure.Services.Auth;

public interface IRegisterService
{
    Task<object?> RegisterAsync(UserForm form);
}
