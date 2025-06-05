using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;
using VideoGame.Functional.Modules.Auth.Factories;
using VideoGame.Functional.Support;
using VideoGame.Infrastructure;

using Xunit.Abstractions;

namespace VideoGame.Functional;

public abstract class TestCase : IClassFixture<TestableWebApplicationFactory>
{
    protected Action<string> Dump;
    protected readonly VideoGameDbContext Context;

    protected readonly HttpClient Client;
    private readonly TestableWebApplicationFactory _factory;

    protected TestCase(
        TestableWebApplicationFactory factory,
        ITestOutputHelper output)
    {
        _factory = factory;
        Context = factory.Resolve<VideoGameDbContext>();
        Client = factory.CreateClient();
        Dump = output.WriteLine;
    }

    protected async Task<User> LoginAsync(User? user = null)
    {
        user ??= UserFactory.Create();
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();
        var token = _factory.Resolve<ITokenGenerator>().CreateToken(user);
        Client.DefaultRequestHeaders.Authorization = new("Bearer", token);

        return user;
    }

    protected async Task<User> LoginWithRoleAsync(string roleName)
    {
        var role = await Context.Roles.FirstAsync(r => r.Name == roleName);
        var user = UserFactory.Create();
        user.RoleId = role.Id;
        await LoginAsync(user);

        return user;
    }
}
