namespace VideoGame.Application.Modules.Auth.Dtos;

public class TokenDto
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}
