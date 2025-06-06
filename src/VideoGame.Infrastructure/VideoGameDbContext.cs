using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Infrastructure;

public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VideoGameDbContext).Assembly);
    }
}
