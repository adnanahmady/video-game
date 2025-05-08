using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Application.Services.Games;

public class CreateGameService(VideoGameDbContext context) : ICreateGameService
{
    public async Task<Game> CreateAsync(CreateGameForm form)
    {
        var game = new Game()
        {
            Title = form.Title,
            Platform = form.Platform,
            Developer = form.Developer,
            Publisher = form.Publisher
        };

        context.Games.Add(game);
        await context.SaveChangesAsync();

        return game;
    }
}
