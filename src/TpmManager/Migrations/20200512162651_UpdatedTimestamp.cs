using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpmManager.Migrations
{
    public partial class UpdatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Posts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Stamp",
                table: "Posts",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Stamp",
                table: "Posts");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
