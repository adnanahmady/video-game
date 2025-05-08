using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Core.Services.Auth;

public interface ILoginService
{
    Task<string?> LoginAsync(UserForm form);
}
