using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.RequestForms.Games;
using VideoGame.Api.Responses.Shared;
using VideoGame.Application.Dtos.Games;
using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Domain.Entities;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class CreateGameController(IGameWork work, IMapper mapper)
    : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Create(CreateGameForm form)
    {
        var dto = mapper.Map<GameDto>(form);
        var game = await work.CreateService.CreateAsync(dto);

        return Created(new Uri("/api/v1/games/" + game.Id),
            new GeneralResource<Game>(game));
    }
}
