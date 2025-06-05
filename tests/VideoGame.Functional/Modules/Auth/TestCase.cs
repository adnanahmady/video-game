using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Functional.Modules.Auth.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Auth;

public abstract class TestCase(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output)
    : ParentTestCase(factory, output)
{
    protected async Task<User> CreateUserAsync(
        string username = "John Doe",
        string password = "SecretPassword",
        string roleName = "User")
    {
        var user = UserFactory.Create(username, password);
        user.RoleId = Context.Roles.FirstOrDefault(r => r.Name == roleName)!.Id;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();

        return user;
    }
}
