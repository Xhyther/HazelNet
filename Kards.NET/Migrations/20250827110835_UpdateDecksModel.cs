using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kards.NET.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecksModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCards",
                table: "Decks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfCards",
                table: "Decks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
