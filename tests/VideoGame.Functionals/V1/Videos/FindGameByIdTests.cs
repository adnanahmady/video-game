using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Bogus.Premium;

using Shouldly;

using VideoGame.Functionals.Factories;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals.V1.Videos;

public class FindGameByIdTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenCalledThenResponseShouldBeAsExpected()
    {
        var video = GameFactory.Create();
        Context.Games.Add(video);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + video.Id;

        var response = await Client.GetFromJsonAsync<JsonElement>(url);

        response.GetProperty("id").GetInt32().ShouldBe(video.Id);
        response.GetProperty("title").GetString().ShouldBe(video.Title);
        response.GetProperty("developer").GetString().ShouldBe(video.Developer);
        response.GetProperty("platform").GetString().ShouldBe(video.Platform);
        response.GetProperty("publisher").GetString().ShouldBe(video.Publisher);
    }

    [Fact]
    public async Task GivenRouteWhenVideoDoesntExistThenShouldBeNotFound()
    {
        var url = @"api/v1/games/9999999999999999";

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var video = GameFactory.Create();
        Context.Games.Add(video);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + video.Id;

        var response = await Client.GetAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
