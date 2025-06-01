using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Infrastructure.Modules.Games.EntityConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder) =>
        builder.HasData(
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
