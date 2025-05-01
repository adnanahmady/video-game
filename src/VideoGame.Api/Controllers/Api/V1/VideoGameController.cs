using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class VideoGameController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Video>> Get() =>
        Ok(context.Videos.ToList());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Video>> FindById(int id)
    {
        var video = await context.Videos.FirstOrDefaultAsync(
            v => v.Id == id);

        if (video is null)
        {
            return NotFound();
        }

        return Ok(video);
    }

    [HttpPost]
    public async Task<ActionResult<Video>> Create(Video @new)
    {
        if (@new is null)
        {
            return BadRequest();
        }

        context.Videos.Add(@new);
        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(FindById),
            new { Id = @new.Id },
            @new
        );
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Video>> Update(
        int id, Video updated)
    {
        var video = await context.Videos.FirstOrDefaultAsync(g => g.Id == id);

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

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Video>> Delete(int id)
    {
        var video = await context.Videos.FirstOrDefaultAsync(
            g => g.Id == id);

        if (video is null)
        {
            return NotFound();
        }

        context.Videos.Remove(video);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
