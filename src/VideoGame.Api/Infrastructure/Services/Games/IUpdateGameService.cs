using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;

namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IUpdateGameService
{
    Task<Game?> UpdateAsync(int id, UpdateGameForm form);

    Task<Game?> UpdateAsync(Game game, UpdateGameForm form);
}
