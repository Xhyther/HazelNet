using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kards.NET.Migrations
{
    /// <inheritdoc />
    public partial class NumberOfCardsToDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfCards",
                table: "Decks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCards",
                table: "Decks");
        }
    }
}
