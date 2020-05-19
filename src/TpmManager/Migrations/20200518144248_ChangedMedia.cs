using Microsoft.EntityFrameworkCore.Migrations;

namespace TpmManager.Migrations
{
    public partial class ChangedMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Machines_MachineId",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Media_MachineId",
                table: "Medias",
                newName: "IX_Medias_MachineId");

            migrationBuilder.AddColumn<string>(
                name: "MediaConnected",
                table: "Medias",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Machines_MachineId",
                table: "Medias",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Machines_MachineId",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MediaConnected",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_MachineId",
                table: "Media",
                newName: "IX_Media_MachineId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Media",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Machines_MachineId",
                table: "Media",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
