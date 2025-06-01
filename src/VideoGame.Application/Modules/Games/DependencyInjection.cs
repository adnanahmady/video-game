using Microsoft.Extensions.DependencyInjection;

using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Application.Modules.Games.Services;

namespace VideoGame.Application.Modules.Games;

public static class DependencyInjection
{
    public static void AddApplicationGamesModule(this IServiceCollection services) =>
        services.AddScoped<IGameWork, GameWork>();
}
