using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kards.NET.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDeckDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeckDescription",
                table: "Decks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeckDescription",
                table: "Decks",
                type: "TEXT",
                nullable: true);
        }
    }
}
