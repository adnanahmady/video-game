using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Games.RequestForms;
using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Application.Modules.Games.Dtos;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Api.Modules.Games.Controllers.Api.V1;

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
