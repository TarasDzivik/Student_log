﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class added_TimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "AspNetUsers",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "AspNetUsers");
        }
    }
}
