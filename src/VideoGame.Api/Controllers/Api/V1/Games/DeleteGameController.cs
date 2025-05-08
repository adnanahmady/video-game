using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class DeleteGameController(IGameWork gameWork) : ControllerBase
{
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Delete(int id)
    {
        var isDeleted = await gameWork.DeleteService.DeleteAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
