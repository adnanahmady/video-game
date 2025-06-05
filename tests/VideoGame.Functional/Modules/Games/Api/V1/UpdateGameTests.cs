using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Modules.Games.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Games.Api.V1;

public class UpdateGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenDataWhenCalledThenShouldReturnExpectedResponse()
    {
        await LoginWithRoleAsync("Admin");
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + game.Id;
        var data = new
        {
            title = "Video title",
            developer = "John Doe",
            platform = "Linux",
            publisher = "John Doe"
        };

        var response = await Client.PutAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var dataSection = content.GetProperty("data");

        dataSection.GetProperty("id").GetInt32().ShouldBe(game.Id);
        dataSection.GetProperty("title").GetString().ShouldBe(data.title);
        dataSection.GetProperty("platform").GetString().ShouldBe(data.platform);
        dataSection.GetProperty("publisher").GetString().ShouldBe(data.publisher);
    }

    [Fact]
    public async Task GivenGameWhenDoesntExistThenShouldBeNotFound()
    {
        await LoginWithRoleAsync("Admin");
        var game = GameFactory.Create();
        Context.Games.Add(game);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/99999999999999999";
        var data = new
        {
            title = game.Title,
            developer = game.Developer,
            platform = game.Platform,
            publisher = game.Publisher
        };

        var response = await Client.PutAsJsonAsync(url, data);

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
        var data = new
        {
            title = game.Title,
            developer = game.Developer,
            platform = game.Platform,
            publisher = game.Publisher
        };

        var response = await Client.PutAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
