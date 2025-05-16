namespace VideoGame.Api.Core.Dtos.Auth;

public class RegisteredUserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
}
