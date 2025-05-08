using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class ShowGameController(IGameWork gameWork) : ControllerBase
{
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Game>> FindById(int id)
    {
        var game = await gameWork.ShowService.ShowAsync(id);

        if (game is null)
        {
            return NotFound();
        }

        return Ok(game);
    }
}
