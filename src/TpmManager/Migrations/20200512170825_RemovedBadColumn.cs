using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpmManager.Migrations
{
    public partial class RemovedBadColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stamp",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Stamp",
                table: "Posts",
                type: "bytea",
                rowVersion: true,
                nullable: true);
        }
    }
}
