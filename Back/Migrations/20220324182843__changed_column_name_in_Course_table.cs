using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class _changed_column_name_in_Course_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course starts since",
                table: "Courses",
                newName: "Starts since");

            migrationBuilder.RenameColumn(
                name: "Course Name",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Starts since",
                table: "Courses",
                newName: "Course starts since");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Course Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }
    }
}
