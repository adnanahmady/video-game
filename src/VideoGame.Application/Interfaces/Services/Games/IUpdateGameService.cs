using VideoGame.Application.Dtos.Games;
using VideoGame.Domain.Entities;

namespace VideoGame.Application.Interfaces.Services.Games;

public interface IUpdateGameService
{
    Task<Game?> UpdateAsync(int id, GameDto form);

    Task<Game?> UpdateAsync(Game game, GameDto form);
}
