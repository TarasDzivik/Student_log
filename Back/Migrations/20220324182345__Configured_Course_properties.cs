using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class _Configured_Course_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Course Name");

            migrationBuilder.RenameColumn(
                name: "DateOdStart",
                table: "Courses",
                newName: "Course starts since");

            migrationBuilder.AlterColumn<string>(
                name: "Course Name",
                table: "Courses",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Course starts since",
                table: "Courses",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course starts since",
                table: "Courses",
                newName: "DateOdStart");

            migrationBuilder.RenameColumn(
                name: "Course Name",
                table: "Courses",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOdStart",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);
        }
    }
}
