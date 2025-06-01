using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Shouldly;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Functional.Factories;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional.V1.Auth;

public class RefreshTokenTests(
    TestableWebApplicationFactory factory,
    ITestOutputHelper output) : TestCase(factory, output)
{
    public static IEnumerable<object[]> DataProviderForDataValidation()
    {
        yield return
        [
            new Func<User, object>(user => new
            {
                user_id = user.Id,
                refresh_token = "pass"
            }),
            "RefreshToken",
            "Refresh token is invalid or expired."
        ];

        yield return
        [
            new Func<User, object>(user => new
            {
                user_id = Guid.NewGuid().ToString(),
                refresh_token = user.RefreshToken
            }),
            "UserId",
            "Refresh token is invalid or expired."
        ];

        yield return
        [
            new Func<User, object>(user => new { refresh_token = user.RefreshToken }),
            "UserId",
            "UserId is required."
        ];

        yield return
        [
            new Func<User, object>(user => new { user_id = user.Id }),
            "RefreshToken",
            "RefreshToken is required."
        ];
    }

    [Theory]
    [MemberData(nameof(DataProviderForDataValidation))]
    public async Task GivenInvalidDataWhenRefreshingThenShouldReturnErrors(
        Func<User, object> fn,
        string field,
        string message)
    {
        var url = @"api/v1/tokens/refresh";
        var user = UserFactory.Create("John due", "SecretPassword");
        user.Role = Context.Roles.FirstOrDefault(r => r.Name == "Admin");
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
        var data = fn(user);

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var errors = content.GetProperty("errors")
            .GetProperty(field).EnumerateArray();

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        errors.First()!.GetString()!.ShouldBe(message);
    }

    [Fact]
    public async Task GivenDataWhenRefreshedThenShouldHaveExpectedFields()
    {
        var url = @"api/v1/tokens/refresh";
        var user = UserFactory.Create("John due", "SecretPassword");
        user.RoleId = Context.Roles.FirstOrDefault(r => r.Name == "User")!.Id;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
        var data = new
        {
            user_id = user.Id,
            refresh_token = user.RefreshToken
        };

        var response = await Guest.PostAsJsonAsync(url, data);
        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var dataSection = content.GetProperty("data");

        dataSection.GetProperty("access_token").GetString().ShouldNotBeNullOrWhiteSpace();
        dataSection.GetProperty("refresh_token").GetString().ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GivenDataWhenRefreshedThenShouldBeOk()
    {
        var url = @"api/v1/tokens/refresh";
        var user = UserFactory.Create("John due", "SecretPassword");
        user.RoleId = Context.Roles.FirstOrDefault(r => r.Name == "User")!.Id;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
        var data = new
        {
            user_id = user.Id,
            refresh_token = user.RefreshToken
        };

        var response = await Guest.PostAsJsonAsync(url, data);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
