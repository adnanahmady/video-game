namespace VideoGame.Application.Modules.Auth.Interfaces;

public interface IAuthWork
{
    ILoginService LoginService { get; set; }
    IRegisterService RegisterService { get; set; }
    IRefreshTokenService RefreshTokenService { get; set; }
}
