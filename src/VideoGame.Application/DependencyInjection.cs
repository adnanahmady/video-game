using Microsoft.Extensions.DependencyInjection;

using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Application.Services.Auth;
using VideoGame.Application.Services.Games;

namespace VideoGame.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IGameWork, GameWork>();
        services.AddScoped<IAuthWork, AuthWork>();

        return services;
    }
}
