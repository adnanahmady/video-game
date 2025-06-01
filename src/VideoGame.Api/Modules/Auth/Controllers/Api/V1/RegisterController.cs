using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Api.Modules.Shared.Support;
using VideoGame.Application.Modules.Auth.Dtos;
using VideoGame.Application.Modules.Auth.Interfaces;

namespace VideoGame.Api.Modules.Auth.Controllers.Api.V1;

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
