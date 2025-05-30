using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using VideoGame.Domain.Interfaces;
using VideoGame.Domain.Interfaces.Support.Auth;
using VideoGame.Domain.Interfaces.Support.Hasher;
using VideoGame.Infrastructure.Support.Auth;
using VideoGame.Infrastructure.Support.Hasher;

namespace VideoGame.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<VideoGameDbContext>(
            options => options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
