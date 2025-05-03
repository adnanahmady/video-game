using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Core.Services.Auth;

public interface ILoginService
{
    Task<string?> LoginAsync(UserForm form);
}
