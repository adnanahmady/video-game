using Microsoft.Extensions.DependencyInjection;

using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Application.Modules.Auth.Services;

namespace VideoGame.Application.Modules.Auth;

public static class DependencyInjection
{
    public static void AddApplicationAuthModule(this IServiceCollection services) =>
        services.AddScoped<IAuthWork, AuthWork>();
}
