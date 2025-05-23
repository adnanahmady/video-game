using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Games;

public class CreateGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    [Fact]
    public async Task GivenDataWhenCalledThenShouldReturnExpectedResponse()
    {
        var url = @"api/v1/games";
        var data = new
        {
            title = "Video title",
            developer = "John Doe",
            platform = "Linux",
            publisher = "John Doe"
        };

        var response = await AdminClient.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var dataSection = content.GetProperty("data");

        dataSection.GetProperty("id").GetInt32().ShouldBeGreaterThan(0);
        dataSection.GetProperty("title").GetString().ShouldBe(data.title);
        dataSection.GetProperty("developer").GetString().ShouldBe(data.developer);
        dataSection.GetProperty("platform").GetString().ShouldBe(data.platform);
        dataSection.GetProperty("publisher").GetString().ShouldBe(data.publisher);
    }

    [Fact]
    public async Task GivenRouteWhenCalledThenShouldBeOk()
    {
        var url = @"api/v1/games";
        var data = new
        {
            title = "Video title",
            developer = "John Doe",
            platform = "Linux",
            publisher = "John Doe"
        };

        var response = await AdminClient.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
