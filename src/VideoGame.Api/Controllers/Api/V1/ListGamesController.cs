using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1;

[Route("api/v1/games")]
[ApiController]
public class ListGamesController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Game>> Get() =>
        Ok(context.Games.ToList());
}
