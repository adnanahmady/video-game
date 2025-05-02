using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/games")]
[ApiController]
public class FindGameByIdController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> FindById(int id)
    {
        var video = await context.Games.FirstOrDefaultAsync(
            v => v.Id == id);

        if (video is null)
        {
            return NotFound();
        }

        return Ok(video);
    }
}
