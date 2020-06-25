using Microsoft.EntityFrameworkCore.Migrations;

namespace APageAway.Migrations
{
    public partial class changedTypeForChapters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalChapters",
                table: "Book",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentChapter",
                table: "Book",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalChapters",
                table: "Book",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "CurrentChapter",
                table: "Book",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
