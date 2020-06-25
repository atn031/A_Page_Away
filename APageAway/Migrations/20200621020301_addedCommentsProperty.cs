using Microsoft.EntityFrameworkCore.Migrations;

namespace APageAway.Migrations
{
    public partial class addedCommentsProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Book");
        }
    }
}
