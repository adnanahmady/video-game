using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/games")]
[ApiController]
public class UpdateGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Game>> Update(
        int id, Game updated)
    {
        var video = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (video is null)
        {
            return NotFound();
        }

        video.Title = updated.Title;
        video.Platform = updated.Platform;
        video.Publisher = updated.Publisher;
        video.Developer = updated.Developer;

        await context.SaveChangesAsync();

        return Ok(video);
    }
}
