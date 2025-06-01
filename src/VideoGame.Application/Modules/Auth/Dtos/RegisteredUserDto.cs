namespace VideoGame.Application.Modules.Auth.Dtos;

public class RegisteredUserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
}
