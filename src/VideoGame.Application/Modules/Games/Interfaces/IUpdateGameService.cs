using VideoGame.Application.Modules.Games.Dtos;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Application.Modules.Games.Interfaces;

public interface IUpdateGameService
{
    Task<Game?> UpdateAsync(int id, GameDto form);

    Task<Game?> UpdateAsync(Game game, GameDto form);
}
