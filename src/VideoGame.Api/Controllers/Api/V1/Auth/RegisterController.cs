using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Responses.Shared;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1")]
[ApiController]
public class RegisterController(IAuthWork authWork) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserForm form)
    {
        var user = await authWork.RegisterService.RegisterAsync(form);

        if (user is null)
        {
            return BadRequest(new CustomError(
                nameof(UserForm.Username),
                "Username already exist!"
            ));
        }

        return Created("/api/v1/login", new GeneralResource<object>(user));
    }
}
