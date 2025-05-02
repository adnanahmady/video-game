using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Bogus.Premium;

using Shouldly;

using VideoGame.Functionals.Factories;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals.V1.Videos;

public class DeleteGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenRouteWhenVideoDoesntExistThenShouldBeNotFound()
    {
        var url = @"api/v1/games/9999999999999999";

        var response = await Client.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var video = GameFactory.Create();
        Context.Games.Add(video);
        await Context.SaveChangesAsync();
        var url = @"api/v1/games/" + video.Id;

        var response = await Client.DeleteAsync(url);

        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
}
