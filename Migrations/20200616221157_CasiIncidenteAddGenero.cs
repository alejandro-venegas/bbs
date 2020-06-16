using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class CasiIncidenteAddGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "CasiIncidentes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_GeneroId",
                table: "CasiIncidentes",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasiIncidentes_Generos_GeneroId",
                table: "CasiIncidentes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasiIncidentes_Generos_GeneroId",
                table: "CasiIncidentes");

            migrationBuilder.DropIndex(
                name: "IX_CasiIncidentes_GeneroId",
                table: "CasiIncidentes");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "CasiIncidentes");
        }
    }
}
