using Microsoft.Extensions.DependencyInjection;

using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;
using VideoGame.Infrastructure.Modules.Auth.Support.Auth;
using VideoGame.Infrastructure.Modules.Auth.Support.Hasher;

namespace VideoGame.Infrastructure.Modules.Auth;

public static class DependencyInjection
{
    public static void AddInfrastructureAuthModule(this IServiceCollection services)
    {
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}
