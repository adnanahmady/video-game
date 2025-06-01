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
public class UpdateGameController(IGameWork gameWork, IMapper mapper) : ControllerBase
{
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Update(
        int id, UpdateGameForm form)
    {
        var dto = mapper.Map<GameDto>(form);
        var game = await gameWork.UpdateService.UpdateAsync(id, dto);

        if (game is null)
        {
            return NotFound();
        }

        return Ok(new GeneralResource<Game>(game));
    }
}
