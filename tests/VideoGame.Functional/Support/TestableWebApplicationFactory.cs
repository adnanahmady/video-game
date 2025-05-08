using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using VideoGame.Api.Core;

namespace VideoGame.Functional.Support;

public class TestableWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        LoadTestSettingFile(builder);

        builder.ConfigureServices((c, services) =>
        {
            RemoveExistingDbContext(services);

            AddDbContextWithTestConnectionString(c, services);

            ApplyMigrationsBeforeTesting(services);
        });
    }

    public T GetDbContext<T>() where T : DbContext => Services
        .CreateScope().ServiceProvider.GetRequiredService<T>();

    private void RemoveExistingDbContext(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(
            d => d.ServiceType == typeof(DbContextOptions<VideoGameDbContext>));

        if (descriptor == null)
        {
            return;
        }

        services.Remove(descriptor);
    }

    private void AddDbContextWithTestConnectionString(
        WebHostBuilderContext context,
        IServiceCollection services)
    {
        var cs = context.Configuration["ConnectionStrings:Testing"];
        services.AddDbContext<VideoGameDbContext>(o => o.UseSqlServer(
            cs,
            opt => opt.EnableRetryOnFailure(5)
        ));
    }

    private void ApplyMigrationsBeforeTesting(IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<VideoGameDbContext>();

        context.Database.EnsureDeleted();
        // context.Database.EnsureCreated();
        context.Database.Migrate();
    }

    private void LoadTestSettingFile(IWebHostBuilder builder) =>
        builder.ConfigureAppConfiguration((c, config) => config.AddJsonFile(
            "appsettings.Testing.json", optional: false, reloadOnChange: true));

    public WebApplicationFactory<Program> Authenticate(string role) =>
        WithWebHostBuilder(builder => builder.ConfigureServices(services => services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Test";
                options.DefaultChallengeScheme = "Test";
            }).AddScheme<TestAuthOptions, TestAuthHandler>(
                "Test",
                o => o.Role = role)));
}
