using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;

namespace VideoGame.Api.Settings;

public static class DatabaseServiceRegisters
{
    public static void AddServices(WebApplicationBuilder builder) =>
        builder.Services.AddDbContext<VideoGameDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
        });
}
