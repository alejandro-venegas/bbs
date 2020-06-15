using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class ChangeSomeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parte",
                table: "ParteCuerpos");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ParteCuerpos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ParteCuerpos");

            migrationBuilder.AddColumn<string>(
                name: "Parte",
                table: "ParteCuerpos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
