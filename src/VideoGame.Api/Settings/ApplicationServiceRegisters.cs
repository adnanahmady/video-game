using VideoGame.Api.Application.Services.Auth;
using VideoGame.Api.Core.Services.Auth;

namespace VideoGame.Api.Settings;

public static class ApplicationServiceRegisters
{
    public static void AddServices(IServiceCollection services) => Auth(services);

    private static void Auth(IServiceCollection services)
    {
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILoginService, LoginService>();
    }
}
