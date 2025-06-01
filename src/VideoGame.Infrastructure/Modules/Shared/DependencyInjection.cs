using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Infrastructure.Modules.Shared;

public static class DependencyInjection
{
    public static void AddInfrastructureSharedModule(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<VideoGameDbContext>(
            options => options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
