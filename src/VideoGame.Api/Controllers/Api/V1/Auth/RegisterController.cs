using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.RequestForms.Auth;
using VideoGame.Api.Responses.Shared;
using VideoGame.Api.Support;
using VideoGame.Application.Dtos.Auth;
using VideoGame.Application.Interfaces.Services.Auth;

namespace VideoGame.Api.Controllers.Api.V1.Auth;

[Tags("Auth")]
[Route("api/v1")]
[ApiController]
public class RegisterController(IAuthWork authWork, IMapper mapper) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserForm form)
    {
        var dto = mapper.Map<UserDto>(form);
        var user = await authWork.RegisterService.RegisterAsync(dto);

        if (user is null)
        {
            return BadRequest(new CustomError(
                nameof(UserForm.Username),
                "Username already exist!"
            ));
        }

        return Created(
            "/api/v1/login",
            new GeneralResource<RegisteredUserDto>(user)
        );
    }
}
