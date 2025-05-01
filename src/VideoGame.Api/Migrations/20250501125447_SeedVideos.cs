using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Developer", "Platform", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Insomniac Games", "PS5", "Sony Interactive Entertainment", "Spider-Man 2" },
                    { 2, "Nintendo EPD", "Nintendo Switch", "Nintendo", "The Legend of Zelda: Tears of the Kingdom" },
                    { 3, "CD Projekt Red", "PC", "CD Projekt", "Cyberpunk 2077" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
