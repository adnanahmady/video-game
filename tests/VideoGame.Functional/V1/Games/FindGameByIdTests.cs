using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Games;

public class FindGameByIdTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenCalledThenResponseShouldBeAsExpected()
    {
        await LoginAsync();
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + game.Id;

        var response = await Client.GetFromJsonAsync<JsonElement>(url);
        var data = response.GetProperty("data");

        data.GetProperty("id").GetInt32().ShouldBe(game.Id);
        data.GetProperty("title").GetString().ShouldBe(game.Title);
        data.GetProperty("developer").GetString().ShouldBe(game.Developer);
        data.GetProperty("platform").GetString().ShouldBe(game.Platform);
        data.GetProperty("publisher").GetString().ShouldBe(game.Publisher);
    }

    [Fact]
    public async Task GivenRouteWhenVideoDoesntExistThenShouldBeNotFound()
    {
        await LoginAsync();
        var url = @"api/v1/games/9999999999999999";

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        await LoginAsync();
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + game.Id;

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
