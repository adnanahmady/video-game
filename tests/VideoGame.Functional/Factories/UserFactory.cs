using Bogus;

using Microsoft.AspNetCore.Identity;

using VideoGame.Api.Core.Entities;

namespace VideoGame.Functional.Factories;

public static class UserFactory
{
    public static User Create() =>
        new Faker<User>()
            .RuleFor(u => u.Username, f => f.Name.JobTitle())
            .RuleFor(
                u => u.PasswordHash,
                f => new PasswordHasher<User>()
                    .HashPassword(new User(), "password")
            )
            .Generate();

    public static User Create(string username, string password) =>
        new Faker<User>()
            .RuleFor(u => u.Username, f => username)
            .RuleFor(
                u => u.PasswordHash,
                f => new PasswordHasher<User>()
                    .HashPassword(new User(), password)
            )
            .RuleFor(
                u => u.RefreshToken,
                f => f.Random.Hash(40)
            )
            .RuleFor(
                u => u.RefreshTokenExpiryTime,
                f => DateTime.UtcNow.AddDays(1)
            )
            .Generate();
}
