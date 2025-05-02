using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/games")]
[ApiController]
public class DeleteGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Game>> Delete(int id)
    {
        var video = await context.Games.FirstOrDefaultAsync(
            g => g.Id == id);

        if (video is null)
        {
            return NotFound();
        }

        context.Games.Remove(video);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
