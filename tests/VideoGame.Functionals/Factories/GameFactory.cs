using Bogus;

using VideoGame.Api.Core.Entities;

namespace VideoGame.Functionals.Factories;

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
}
