using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Settings;

public static class AppSupportRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
    }
}
