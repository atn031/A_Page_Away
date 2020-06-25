using Microsoft.EntityFrameworkCore.Migrations;

namespace APageAway.Migrations
{
    public partial class BookDBCreationWithImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Book");
        }
    }
}
