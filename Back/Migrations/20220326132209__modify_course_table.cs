using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class _modify_course_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Courses",
                newName: "TitleImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleImagePath",
                table: "Courses",
                newName: "ImagePath");
        }
    }
}
