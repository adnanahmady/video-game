using System.Net;

using Shouldly;

using VideoGame.Functional.Modules.Games.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Games.Api.V1;

public class DeleteGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenVideoDoesntExistThenShouldBeNotFound()
    {
        await LoginWithRoleAsync("Admin");
        var url = @"api/v1/games/9999999999999999";

        var response = await Client.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        await LoginWithRoleAsync("Admin");
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + game.Id;

        var response = await Client.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
}
