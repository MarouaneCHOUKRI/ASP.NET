using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universite.Data.Migrations
{
    public partial class CleUeFormation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UeSuivieID",
                table: "UE",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UE_UeSuivieID",
                table: "UE",
                column: "UeSuivieID");

            migrationBuilder.AddForeignKey(
                name: "FK_UE_Formation_UeSuivieID",
                table: "UE",
                column: "UeSuivieID",
                principalTable: "Formation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UE_Formation_UeSuivieID",
                table: "UE");

            migrationBuilder.DropIndex(
                name: "IX_UE_UeSuivieID",
                table: "UE");

            migrationBuilder.DropColumn(
                name: "UeSuivieID",
                table: "UE");
        }
    }
}
