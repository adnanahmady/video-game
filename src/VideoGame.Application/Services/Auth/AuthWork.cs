using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Domain.Interfaces;
using VideoGame.Domain.Interfaces.Support.Auth;
using VideoGame.Domain.Interfaces.Support.Hasher;

namespace VideoGame.Application.Services.Auth;

public class AuthWork(
    IUnitOfWork unitOfWork,
    ITokenGenerator tokenGenerator,
    IPasswordHasher passwordHasher) : IAuthWork
{
    public ILoginService LoginService { get; set; } =
        new LoginService(unitOfWork, tokenGenerator, passwordHasher);

    public IRegisterService RegisterService { get; set; } =
        new RegisterService(unitOfWork, passwordHasher);

    public IRefreshTokenService RefreshTokenService { get; set; } =
        new RefreshTokenService(tokenGenerator);
}
