using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IListGamesService
{
    Task<ICollection<Game>> GetPaginatedAsync(int skip, int take);

    Task<int> GetTotalAsync();
}
