using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class CasiIncidenteAddGenero2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionCasiIncidente",
                table: "CasiIncidentes");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "CasiIncidentes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "CasiIncidentes");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionCasiIncidente",
                table: "CasiIncidentes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
