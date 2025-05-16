using AutoMapper;

using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class UpdateGameService(VideoGameDbContext context, IMapper mapper) : IUpdateGameService
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
        mapper.Map(form, game);

        await context.SaveChangesAsync();

        return game;
    }
}
