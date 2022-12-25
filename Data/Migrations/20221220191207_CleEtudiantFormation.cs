using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universite.Data.Migrations
{
    public partial class CleEtudiantFormation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormationSuivieID",
                table: "Etudiant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_FormationSuivieID",
                table: "Etudiant",
                column: "FormationSuivieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiant_Formation_FormationSuivieID",
                table: "Etudiant",
                column: "FormationSuivieID",
                principalTable: "Formation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiant_Formation_FormationSuivieID",
                table: "Etudiant");

            migrationBuilder.DropIndex(
                name: "IX_Etudiant_FormationSuivieID",
                table: "Etudiant");

            migrationBuilder.DropColumn(
                name: "FormationSuivieID",
                table: "Etudiant");
        }
    }
}
