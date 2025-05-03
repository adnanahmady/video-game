using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Games;

public class ListGamesTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenCalledThenResponseShouldBeAsExpected()
    {
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games";

        var response = await Client.GetFromJsonAsync<JsonElement>(url);

        var item = response.EnumerateArray().Last();
        item.GetProperty("id").GetInt32().ShouldBe(game.Id);
        item.GetProperty("title").GetString().ShouldBe(game.Title);
        item.GetProperty("developer").GetString().ShouldBe(game.Developer);
        item.GetProperty("platform").GetString().ShouldBe(game.Platform);
        item.GetProperty("publisher").GetString().ShouldBe(game.Publisher);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var url = @"api/v1/games";

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
