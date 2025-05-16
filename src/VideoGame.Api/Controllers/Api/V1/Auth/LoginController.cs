using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Dtos.Auth;
using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Responses.Shared;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1/login")]
[ApiController]
public class LoginController(IAuthWork authWork) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login(UserForm form)
    {
        var token = await authWork.LoginService.LoginAsync(form);

        if (token is null)
        {
            return BadRequest(new CustomError(
                nameof(UserForm.Username),
                "Username or Password is wrong!"
            ));
        }

        return Ok(new GeneralResource<TokenDto>(token));
    }
}
