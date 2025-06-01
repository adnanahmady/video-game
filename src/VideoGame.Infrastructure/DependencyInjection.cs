using Microsoft.Extensions.DependencyInjection;

using VideoGame.Infrastructure.Modules.Auth;
using VideoGame.Infrastructure.Modules.Shared;

namespace VideoGame.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddInfrastructureSharedModule(connectionString);
        services.AddInfrastructureAuthModule();

        return services;
    }
}
