using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Services.Auth;
using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1/login")]
[ApiController]
public class LoginController(ILoginService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login(UserForm form)
    {
        var token = await service.LoginAsync(form);

        if (token is null)
        {
            return BadRequest(new
            {
                Message = "Username or Password is wrong!"
            });
        }

        return Ok(new { Token = token });
    }
}
