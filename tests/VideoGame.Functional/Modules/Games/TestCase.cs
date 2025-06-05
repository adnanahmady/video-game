using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Functional.Modules.Games.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Games;

public abstract class TestCase(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output)
    : ParentTestCase(factory, output)
{
    protected async Task<Game> CreateGameAsync()
    {
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();

        return game;
    }
}
