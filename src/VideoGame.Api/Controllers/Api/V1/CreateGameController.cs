using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/games")]
[ApiController]
public class CreateGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpPost]
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
