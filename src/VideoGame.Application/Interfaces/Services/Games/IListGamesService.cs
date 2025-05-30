using VideoGame.Domain.Entities;

namespace VideoGame.Application.Interfaces.Services.Games;

public interface IListGamesService
{
    Task<ICollection<Game>> GetPaginatedAsync(int skip, int take);

    Task<int> GetTotalAsync();
}
