using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Application.Services.Games;

public class ShowGameService(VideoGameDbContext context) : IShowGameService
{
    public async Task<Game?> ShowAsync(int id)
    {
        var game = await context.Games.FirstOrDefaultAsync(v => v.Id == id);

        if (game is null)
        {
            return null;
        }

        return game;
    }
}
