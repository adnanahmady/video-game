namespace VideoGame.Application.Dtos.Auth;

public class RefreshTokenDto
{
    public Guid UserId { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
}
