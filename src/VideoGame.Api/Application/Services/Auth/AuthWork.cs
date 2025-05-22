using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Application.Services.Auth;

public class AuthWork(
    IUnitOfWork unitOfWork,
    ITokenGenerator tokenGenerator) : IAuthWork
{
    public ILoginService LoginService { get; set; } =
        new LoginService(unitOfWork, tokenGenerator);

    public IRegisterService RegisterService { get; set; } =
        new RegisterService(unitOfWork);

    public IRefreshTokenService RefreshTokenService { get; set; } =
        new RefreshTokenService(tokenGenerator);
}
