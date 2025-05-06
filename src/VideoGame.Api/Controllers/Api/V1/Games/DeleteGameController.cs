using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class DeleteGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Delete(int id)
    {
        var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
        {
            return NotFound();
        }

        context.Games.Remove(game);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
