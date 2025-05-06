using System.Net;

using Shouldly;

using VideoGame.Functional.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Games;

public class DeleteGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenVideoDoesntExistThenShouldBeNotFound()
    {
        var url = @"api/v1/games/9999999999999999";

        var response = await AdminClient.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + game.Id;

        var response = await AdminClient.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
}
