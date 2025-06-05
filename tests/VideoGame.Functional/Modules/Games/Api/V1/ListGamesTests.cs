using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;

using Shouldly;

using VideoGame.Functional.Modules.Games.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Games.Api.V1;

public class ListGamesTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenPaginationParametersWhenCalledThenResponseShouldBeAsExpected()
    {
        // Arrange
        await LoginAsync();
        await Context.Games.ExecuteDeleteAsync();
        var games = GameFactory.CreateMany(4);
        Context.Games.AddRange(games);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games?page=2&pageSize=3";

        // Act
        var response = await Client.GetFromJsonAsync<JsonElement>(url);
        var item = response.GetProperty("data").EnumerateArray().Last();
        var pagination = response.GetProperty("meta").GetProperty("pagination");

        // Assert
        item.GetProperty("id").GetInt32().ShouldBe(games[3].Id);
        item.GetProperty("title").GetString().ShouldBe(games[3].Title);
        item.GetProperty("developer").GetString().ShouldBe(games[3].Developer);
        item.GetProperty("platform").GetString().ShouldBe(games[3].Platform);
        item.GetProperty("publisher").GetString().ShouldBe(games[3].Publisher);
        pagination.GetProperty("page").GetInt32().ShouldBe(2);
        pagination.GetProperty("page_size").GetInt32().ShouldBe(3);
        pagination.GetProperty("total_items").GetInt32().ShouldBe(4);
        pagination.GetProperty("total_pages").GetInt32().ShouldBe(2);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenResponseShouldBeAsExpected()
    {
        await LoginAsync();
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games";

        var response = await Client.GetFromJsonAsync<JsonElement>(url);

        var item = response.GetProperty("data").EnumerateArray().Last();
        item.GetProperty("id").GetInt32().ShouldBe(game.Id);
        item.GetProperty("title").GetString().ShouldBe(game.Title);
        item.GetProperty("developer").GetString().ShouldBe(game.Developer);
        item.GetProperty("platform").GetString().ShouldBe(game.Platform);
        item.GetProperty("publisher").GetString().ShouldBe(game.Publisher);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        await LoginAsync();
        var url = @"api/v1/games";

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
