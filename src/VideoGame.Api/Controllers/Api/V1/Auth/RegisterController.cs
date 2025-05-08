using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;

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
            return BadRequest(new
            {
                errors = new Dictionary<string, string[]>()
                {
                    { nameof(UserForm.Username), new[] { "Username already exist!" } }
                }
            });
        }

        return Created("/api/v1/login", user);
    }
}
