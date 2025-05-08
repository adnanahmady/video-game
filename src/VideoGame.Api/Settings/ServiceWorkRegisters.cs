using VideoGame.Api.Application.Services.Auth;
using VideoGame.Api.Application.Services.Games;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Settings;

public static class ServiceWorkRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IAuthWork, AuthWork>();
        services.AddScoped<IGameWork, GameWork>();
    }
}
