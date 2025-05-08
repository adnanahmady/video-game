using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class UpdateGameController(IGameWork gameWork) : ControllerBase
{
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Update(
        int id, UpdateGameForm form)
    {
        var game = await gameWork.UpdateService.UpdateAsync(id, form);

        if (game is null)
        {
            return NotFound();
        }

        return Ok(game);
    }
}
