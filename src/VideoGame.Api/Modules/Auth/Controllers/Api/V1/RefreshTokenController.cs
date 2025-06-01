using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Api.Modules.Shared.Support;
using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;

namespace VideoGame.Api.Modules.Auth.Controllers.Api.V1;

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
