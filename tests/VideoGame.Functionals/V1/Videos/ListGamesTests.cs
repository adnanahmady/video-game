using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functionals.Factories;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals.V1.Videos;

public class ListGamesTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenCalledThenResponseShouldBeAsExpected()
    {
        var video = GameFactory.Create();
        Context.Games.Add(video);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games";

        var response = await Client.GetFromJsonAsync<JsonElement>(url);

        var item = response.EnumerateArray().Last();
        item.GetProperty("id").GetInt32().ShouldBe(video.Id);
        item.GetProperty("title").GetString().ShouldBe(video.Title);
        item.GetProperty("developer").GetString().ShouldBe(video.Developer);
        item.GetProperty("platform").GetString().ShouldBe(video.Platform);
        item.GetProperty("publisher").GetString().ShouldBe(video.Publisher);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var url = @"api/v1/games";

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
