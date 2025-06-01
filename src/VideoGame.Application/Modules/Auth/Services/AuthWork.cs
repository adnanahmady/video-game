using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Auth.Services;

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
