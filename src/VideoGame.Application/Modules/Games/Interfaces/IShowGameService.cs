using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Application.Modules.Games.Interfaces;

public interface IShowGameService
{
    Task<Game?> ShowAsync(int id);
}
