using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IShowGameService
{
    Task<Game?> ShowAsync(int id);
}
