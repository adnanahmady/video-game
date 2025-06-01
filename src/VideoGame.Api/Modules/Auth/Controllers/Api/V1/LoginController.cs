using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Api.Modules.Shared.Support;
using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;

namespace VideoGame.Api.Modules.Auth.Controllers.Api.V1;

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
