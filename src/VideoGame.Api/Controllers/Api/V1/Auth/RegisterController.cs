using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Services.Auth;
using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1")]
[ApiController]
public class RegisterController(IRegisterService service) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserForm form)
    {
        var user = await service.RegisterAsync(form);

        if (user is null)
        {
            return BadRequest(new
            {
                Message = "Username already exists"
            });
        }

        return Created("/api/v1/login", user);
    }
}
