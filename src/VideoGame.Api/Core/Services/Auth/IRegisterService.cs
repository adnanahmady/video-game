using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Core.Services.Auth;

public interface IRegisterService
{
    Task<object?> RegisterAsync(UserForm form);
}
