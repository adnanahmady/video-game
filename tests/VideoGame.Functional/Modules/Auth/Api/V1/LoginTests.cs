using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.Modules.Auth.Api.V1;

public class LoginTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    public static IEnumerable<object[]> DataProviderForDataValidation()
    {
        yield return
        [
            new { username = "user", password = "pass" },
            "Password",
            "Password must be at least 6 characters long."
        ];

        yield return
        [
            new { username = "us", password = "SecretPassword" },
            "Username",
            "Username must be between 3 and 60 characters long."
        ];

        yield return
        [
            new { password = "SecretPassword" },
            "Username",
            "Username is required."
        ];

        yield return
        [
            new { username = "John due" },
            "Password",
            "Password is required."
        ];
    }

    [Theory]
    [MemberData(nameof(DataProviderForDataValidation))]
    public async Task GivenInvalidDataWhenLoginThenShouldReturnErrors(
        object data,
        string field,
        string message)
    {
        var url = @"api/v1/login";
        await CreateUserAsync(roleName: "Admin");
        var response = await Client.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var errors = content.GetProperty("errors")
            .GetProperty(field).EnumerateArray();

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        errors.First()!.GetString()!.ShouldBe(message);
    }

    [Fact]
    public async Task GivenDataWhenLoggedInThenReturnNewToken()
    {
        var url = @"api/v1/login";
        await CreateUserAsync(roleName: "User");
        var data = new
        {
            username = "John Doe",
            password = "SecretPassword"
        };

        var response = await Client.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var dataSection = content.GetProperty("data");

        dataSection.GetProperty("access_token").GetString().ShouldNotBeNullOrWhiteSpace();
        dataSection.GetProperty("refresh_token").GetString().ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GivenDataWhenLoggedInThenShouldBeOk()
    {
        var url = @"api/v1/login";
        await CreateUserAsync(username: "john doe 2", roleName: "User");
        var data = new
        {
            username = "john doe 2",
            password = "SecretPassword"
        };

        var response = await Client.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
