using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Api.Modules.Games.Controllers.Api.V1;

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
