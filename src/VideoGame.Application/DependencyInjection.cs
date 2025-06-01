using Microsoft.Extensions.DependencyInjection;

using VideoGame.Application.Modules.Auth;
using VideoGame.Application.Modules.Games;

namespace VideoGame.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddApplicationAuthModule();
        services.AddApplicationGamesModule();

        return services;
    }
}
