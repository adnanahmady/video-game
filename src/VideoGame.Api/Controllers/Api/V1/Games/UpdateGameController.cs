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
