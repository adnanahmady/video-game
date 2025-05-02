using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Bogus.Premium;

using Shouldly;

using VideoGame.Functionals.Factories;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals.V1.Videos;

public class UpdateGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenDataWhenCalledThenShouldReturnExpectedResponse()
    {
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

         content.GetProperty("id").GetInt32().ShouldBe(game.Id);
         content.GetProperty("title").GetString().ShouldBe(data.title);
         content.GetProperty("platform").GetString().ShouldBe(data.platform);
         content.GetProperty("publisher").GetString().ShouldBe(data.publisher);
    }

    [Fact]
    public async Task GivenGameWhenDoesntExistThenShouldBeNotFound()
    {
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
