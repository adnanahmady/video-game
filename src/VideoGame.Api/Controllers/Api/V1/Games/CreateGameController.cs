using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Controllers.Api.V1.Games;

[Tags("Games")]
[Route("api/v1/games")]
[ApiController]
public class CreateGameController(IGameWork work)
    : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Game>> Create(CreateGameForm form)
    {
        var game = await work.CreateService.CreateAsync(form);

        return Created(new Uri("/api/v1/games/" + game.Id), game);
    }
}
