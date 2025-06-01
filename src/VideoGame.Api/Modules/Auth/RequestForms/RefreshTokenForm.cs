namespace VideoGame.Api.Modules.Auth.RequestForms;

public class RefreshTokenForm
{
    public Guid UserId { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
}
