using Microsoft.EntityFrameworkCore.Migrations;

namespace APageAway.Migrations
{
    public partial class addedArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Book");
        }
    }
}
