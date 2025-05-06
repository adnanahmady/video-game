using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Authorize]
[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class ListGamesController(VideoGameDbContext context)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Game>> Get() =>
        Ok(context.Games.ToList());
}
