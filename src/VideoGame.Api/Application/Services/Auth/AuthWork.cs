using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Application.Services.Auth;

public class AuthWork(
    VideoGameDbContext context,
    ITokenGenerator tokenGenerator) : IAuthWork
{
    public ILoginService LoginService { get; set; } =
        new LoginService(context, tokenGenerator);

    public IRegisterService RegisterService { get; set; } =
        new RegisterService(context);

    public IRefreshTokenService RefreshTokenService { get; set; } =
        new RefreshTokenService(tokenGenerator);
}
