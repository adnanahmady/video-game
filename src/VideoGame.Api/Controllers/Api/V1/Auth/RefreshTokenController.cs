using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1/tokens/refresh")]
[ApiController]
public class RefreshTokenController(IAuthWork authWork) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login(RefreshTokenForm form)
    {
        var token = await authWork.RefreshTokenService.RefreshAsync(form);

        return Ok(token);
    }
}
