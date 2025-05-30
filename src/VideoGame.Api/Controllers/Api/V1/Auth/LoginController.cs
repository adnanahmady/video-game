using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.RequestForms.Auth;
using VideoGame.Api.Responses.Shared;
using VideoGame.Api.Support;
using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1/login")]
[ApiController]
public class LoginController(IAuthWork authWork, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login(UserForm form)
    {
        var dto = mapper.Map<UserDto>(form);
        var token = await authWork.LoginService.LoginAsync(dto);

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
