using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class CreateGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Create(Game @new)
    {
        if (@new is null)
        {
            return BadRequest();
        }

        context.Games.Add(@new);
        await context.SaveChangesAsync();

        return Created(new Uri("/api/v1/games/" + @new.Id), @new);
    }
}
