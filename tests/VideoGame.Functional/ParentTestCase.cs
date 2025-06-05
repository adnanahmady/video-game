using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;
using VideoGame.Functional.Modules.Auth.Factories;
using VideoGame.Functional.Support;
using VideoGame.Infrastructure;

using Xunit.Abstractions;

namespace VideoGame.Functional;

public abstract class ParentTestCase(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output)
    : IClassFixture<TestableWebApplicationFactory>
{
    protected Action<string> Dump = output.WriteLine;
    protected readonly VideoGameDbContext Context =
        factory.Resolve<VideoGameDbContext>();
    protected readonly HttpClient Client = factory.CreateClient();

    protected async Task<User> LoginAsync(User? user = null)
    {
        user ??= UserFactory.Create();
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();
        var token = factory.Resolve<ITokenGenerator>().CreateToken(user);
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
