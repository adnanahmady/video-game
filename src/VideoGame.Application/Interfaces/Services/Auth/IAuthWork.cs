namespace VideoGame.Application.Interfaces.Services.Auth;

public interface IAuthWork
{
    ILoginService LoginService { get; set; }
    IRegisterService RegisterService { get; set; }
    IRefreshTokenService RefreshTokenService { get; set; }
}
