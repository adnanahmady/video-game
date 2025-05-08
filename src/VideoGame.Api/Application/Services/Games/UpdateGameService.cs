using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class UpdateGameService(VideoGameDbContext context) : IUpdateGameService
{
    public async Task<Game?> UpdateAsync(int id, UpdateGameForm form)
    {
        var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
        {
            return null;
        }

        return await UpdateAsync(game, form);
    }

    public async Task<Game?> UpdateAsync(Game game, UpdateGameForm form)
    {
        game.Title = form.Title;
        game.Platform = form.Platform;
        game.Publisher = form.Publisher;
        game.Developer = form.Developer;

        await context.SaveChangesAsync();

        return game;
    }
}
