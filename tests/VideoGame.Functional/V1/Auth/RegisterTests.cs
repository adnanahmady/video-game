using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Auth;

public class RegisterTests(
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
    public async Task GivenInvalidDataWhenRegisterThenShouldReturnErrors(
        object data,
        string field,
        string message)
    {
        var url = @"api/v1/register";

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var errors = content.GetProperty("errors")
            .GetProperty(field).EnumerateArray();

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        errors.First()!.GetString()!.ShouldBe(message);
    }

    [Fact]
    public async Task GivenDataWhenRegisteredThenReturnExpectedFields()
    {
        var url = @"api/v1/register";
        var data = new
        {
            username = "John due",
            password = "SecretPassword"
        };

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var dataSection = content.GetProperty("data");

        dataSection.GetProperty("id").GetString().ShouldNotBeNullOrWhiteSpace();
        dataSection.GetProperty("username").GetString().ShouldBe(data.username);
    }

    [Fact]
    public async Task GivenUsernameAndPasswordWhenCalledThenShouldRegister()
    {
        var url = @"api/v1/register";
        var data = new
        {
            username = "John due",
            password = "SecretPassword"
        };

        var response = await Guest.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
