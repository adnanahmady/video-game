using VideoGame.Application.Interfaces.Services.Auth;
using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Application.Services.Auth;
using VideoGame.Application.Services.Games;

namespace VideoGame.Api.Settings;

public static class ServiceWorkRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IAuthWork, AuthWork>();
        services.AddScoped<IGameWork, GameWork>();
    }
}
