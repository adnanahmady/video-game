using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Functional.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Auth;

public class LoginTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    public static IEnumerable<object[]> DataProviderForDataValidation()
    {
        yield return new object[]
        {
            new { username = "user", password = "pass" },
            "Password",
            "Password must be at least 6 characters long.",
        };

        yield return new object[]
        {
            new { username = "us", password = "SecretPassword" },
            "Username",
            "Username must be between 3 and 60 characters long.",
        };

        yield return new object[]
        {
            new { password = "SecretPassword" },
            "Username",
            "Username is required.",
        };

        yield return new object[]
        {
            new { username = "John due" },
            "Password",
            "Password is required.",
        };
    }

    [Theory]
    [MemberData(nameof(DataProviderForDataValidation))]
    public async Task GivenInvalidDataWhenLoginThenShouldReturnErrors(
        object data,
        string field,
        string message)
    {
        var url = @"api/v1/login";
        var user = UserFactory.Create("John due", "SecretPassword");
        user.Role = Context.Roles.FirstOrDefault(r => r.Name == "Admin");
        Context.Users.Add(user);
        await Context.SaveChangesAsync();

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var errors = content.GetProperty("errors")
            .GetProperty(field).EnumerateArray();

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        errors.First()!.GetString()!.ShouldBe(message);
    }

    [Fact]
    public async Task GivenDataWhenRegisteredSuccessfullyThenShouldReturnExpectedResponse()
    {
        var url = @"api/v1/login";
        var user = UserFactory.Create("John due", "SecretPassword");
        user.RoleId = Context.Roles.FirstOrDefault(r => r.Name == "User")!.Id;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
        var data = new
        {
            username = "John due",
            password = "SecretPassword"
        };

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();

        content.GetProperty("token").GetString().ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GivenUsernameAndPasswordWhenCalledThenShouldRegister()
    {
        var url = @"api/v1/login";
        var user = UserFactory.Create("John due2", "SecretPassword");
        user.RoleId = Context.Roles.FirstOrDefault(r => r.Name == "User")!.Id;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
        var data = new
        {
            username = "John due2",
            password = "SecretPassword"
        };

        var response = await Guest.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
