using Bogus;

using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Functional.Factories;

public static class RoleFactory
{
    public static Role Create() =>
        new Faker<Role>()
            .RuleFor(r => r.Name, f => f.Name.JobTitle())
            .Generate();

    public static Role Create(string name) =>
        new Faker<Role>()
            .RuleFor(r => r.Name, f => name)
            .Generate();
}
