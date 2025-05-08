using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.EntityConfigurations;

namespace VideoGame.Api.Core;

public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                Id = 1,
                Name = "Admin"
            },
            new Role()
            {
                Id = 2,
                Name = "User"
            }
        );

        modelBuilder.Entity<Game>().HasData(
            new Game()
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interactive Entertainment"
            },
            new Game()
            {
                Id = 2,
                Title = "The Legend of Zelda: Tears of the Kingdom",
                Platform = "Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo"
            },
            new Game()
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt"
            }
        );
    }
}
