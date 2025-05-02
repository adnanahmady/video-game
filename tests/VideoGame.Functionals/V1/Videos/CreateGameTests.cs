using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Bogus.Premium;

using Shouldly;

using VideoGame.Functionals.Factories;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals.V1.Videos;

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

         var response = await Client.PostAsJsonAsync(url, data);
         var content = await response.Content.ReadFromJsonAsync<JsonElement>();

         content.GetProperty("id").GetInt32().ShouldBeGreaterThan(0);
         content.GetProperty("title").GetString().ShouldBe(data.title);
         content.GetProperty("developer").GetString().ShouldBe(data.developer);
         content.GetProperty("platform").GetString().ShouldBe(data.platform);
         content.GetProperty("publisher").GetString().ShouldBe(data.publisher);
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

        var response = await Client.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
