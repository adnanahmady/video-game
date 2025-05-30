using VideoGame.Domain.Entities;

namespace VideoGame.Application.Interfaces.Services.Games;

public interface IShowGameService
{
    Task<Game?> ShowAsync(int id);
}
