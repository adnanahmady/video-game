using VideoGame.Api.Application.Services.Games;
using VideoGame.Api.Infrastructure.Services;

namespace VideoGame.Api.Settings;

public static class ServiceWorkRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IGameWork, GameWork>();
    }
}
