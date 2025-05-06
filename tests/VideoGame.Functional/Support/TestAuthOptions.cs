using Microsoft.AspNetCore.Authentication;

namespace VideoGame.Functional.Support;

public class TestAuthOptions : AuthenticationSchemeOptions
{
    public string Role { get; set; } = "User";
}
