using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class ListGameService(VideoGameDbContext context) : IListGameService
{
    public async Task<ICollection<Core.Entities.Game>> GetPaginatedAsync(int skip, int take) =>
        await context.Games.Skip(skip).Take(take).ToListAsync();
}
