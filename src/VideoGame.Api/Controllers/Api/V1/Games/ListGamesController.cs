using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Authorize]
[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class ListGamesController(IGameWork gameWork)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Game>>> Get(int? pageNumber, int? pageSize) => Ok(
        await gameWork.ListService.GetPaginatedAsync(pageNumber ?? 1, pageSize ?? 15)
    );
}
