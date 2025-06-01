using VideoGame.Api.Modules.Auth;
using VideoGame.Api.Modules.Games;

namespace VideoGame.Api.Modules;

public static class ModuleRegistration
{
    public static IServiceCollection AddApiModules(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApiAuthModule(configuration);
        services.AddApiGamesModule();

        return services;
    }
}
