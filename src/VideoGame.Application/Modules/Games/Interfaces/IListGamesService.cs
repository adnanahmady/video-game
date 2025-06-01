using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Application.Modules.Games.Interfaces;

public interface IListGamesService
{
    Task<ICollection<Game>> GetPaginatedAsync(int skip, int take);

    Task<int> GetTotalAsync();
}
