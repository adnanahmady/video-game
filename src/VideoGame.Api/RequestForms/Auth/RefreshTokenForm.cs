namespace VideoGame.Api.RequestForms.Auth;

public class RefreshTokenForm
{
    public Guid UserId { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
}
