using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class ListGamesesService(VideoGameDbContext context) : IListGamesService
{
    public async Task<ICollection<Game>> GetPaginatedAsync(int page, int pageSize) =>
        await context.Games
            .OrderBy(g => g.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task<int> GetTotalAsync() => await context.Games.CountAsync();
}
