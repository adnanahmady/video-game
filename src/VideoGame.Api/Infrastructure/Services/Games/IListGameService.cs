using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IListGameService
{
    Task<ICollection<Game>> GetPaginatedAsync(int skip, int take);
}
