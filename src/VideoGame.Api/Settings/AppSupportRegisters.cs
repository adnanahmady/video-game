using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Settings;

public static class AppSupportRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ITokenGenerator, TokenGenerator>();
    }
}
