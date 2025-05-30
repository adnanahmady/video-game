using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.RequestForms.Auth;
using VideoGame.Api.Responses.Shared;
using VideoGame.Api.Support;
using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1/tokens/refresh")]
[ApiController]
public class RefreshTokenController(IAuthWork authWork, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login(RefreshTokenForm form)
    {
        var dto = mapper.Map<RefreshTokenDto>(form);
        var token = await authWork.RefreshTokenService.RefreshAsync(dto);

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
