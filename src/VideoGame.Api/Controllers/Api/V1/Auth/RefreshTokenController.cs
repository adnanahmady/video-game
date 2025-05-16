using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Dtos.Auth;
using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Responses.Shared;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support;

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

        if (token is null)
        {
            return BadRequest(new CustomError(
                nameof(RefreshTokenForm.RefreshToken),
                "Refresh token is invalid."
            ));
        }

        return Ok(new GeneralResource<TokenDto>(token));
    }
}
