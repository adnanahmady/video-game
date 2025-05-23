using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Responses.Shared;
using VideoGame.Api.Infrastructure.Services.Games;

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
    public async Task<ActionResult<PaginatedResponse<Game>>> Get(
        int? page, int? pageSize) => Ok(new PaginatedResponse<Game>(
            await gameWork.ListService.GetPaginatedAsync(page ?? 1, pageSize ?? 15),
            page ?? 1,
            pageSize ?? 15,
            await gameWork.ListService.GetTotalAsync()
        ));
}
