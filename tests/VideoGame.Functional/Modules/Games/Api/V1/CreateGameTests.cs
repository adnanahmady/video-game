using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Games.Api.V1;

public class CreateGameTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output)
    : TestCase(factory, output)
{
    [Fact]
    public async Task GivenDataWhenCalledThenShouldReturnExpectedResponse()
    {
        await LoginWithRoleAsync("Admin");
        var url = @"api/v1/games";
        var data = new
        {
            title = "Video title",
            developer = "John Doe",
            platform = "Linux",
            publisher = "John Doe"
        };

        var response = await Client.PostAsJsonAsync(url, data);
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
        await LoginWithRoleAsync("Admin");
        var url = @"api/v1/games";
        var data = new
        {
            title = "Video title",
            developer = "John Doe",
            platform = "Linux",
            publisher = "John Doe"
        };

        var response = await Client.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
