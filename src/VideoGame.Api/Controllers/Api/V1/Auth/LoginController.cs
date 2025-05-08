using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;

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
            return BadRequest(new
            {
                errors = new Dictionary<string, string[]>()
                {
                    { nameof(UserForm.Username), new[] { "Username or Password is wrong!" } }
                }
            });
        }

        return Ok(token);
    }
}
