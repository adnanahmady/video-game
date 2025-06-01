using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Modules.Shared.Responses;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Api.Modules.Games.Controllers.Api.V1
{
    [Tags("Games")]
    [Route("api/v1/games")]
    [ApiController]
    public class ShowGameController(IGameWork gameWork) : ControllerBase
    {
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Game>> FindById(int id)
        {
            var game = await gameWork.ShowService.ShowAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            return Ok(new GeneralResource<Game>(game));
        }
    }
}
