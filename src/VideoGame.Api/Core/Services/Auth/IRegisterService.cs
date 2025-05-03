using VideoGame.Api.Core.Entities;
using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Core.Services.Auth;

public interface IRegisterService
{
    Task<User?> RegisterAsync(UserForm form);
}
