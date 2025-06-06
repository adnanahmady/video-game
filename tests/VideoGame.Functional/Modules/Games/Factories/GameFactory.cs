using Bogus;

using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Functional.Modules.Games.Factories;

public static class GameFactory
{
    public static Game Create() =>
        new Faker<Game>()
            .RuleFor(v => v.Title, f => f.Name.JobTitle())
            .RuleFor(v => v.Developer, f => f.Name.FullName())
            .RuleFor(v => v.Platform, f => f.PickRandom<string>(
                new string[] { "Linux", "Mac", "Windows" }))
            .RuleFor(v => v.Publisher, f => f.Name.FullName())
            .Generate();

    public static IList<Game> CreateMany(int count)
    {
        var games = new List<Game>();

        for (var i = 0; i < count; i++)
        {
            games.Add(Create());
        }

        return games;
    }
}
