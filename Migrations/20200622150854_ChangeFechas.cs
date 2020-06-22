using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class ChangeFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIncidente",
                table: "Incidentes");

            migrationBuilder.DropColumn(
                name: "FechaCondicion",
                table: "CondicionInseguras");

            migrationBuilder.DropColumn(
                name: "FechaCasiIncidente",
                table: "CasiIncidentes");

            migrationBuilder.DropColumn(
                name: "FechaBbs",
                table: "Bbss");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Incidentes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "CondicionInseguras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "CasiIncidentes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Fecha",
                table: "Bbss",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Incidentes");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "CondicionInseguras");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "CasiIncidentes");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Bbss");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIncidente",
                table: "Incidentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCondicion",
                table: "CondicionInseguras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCasiIncidente",
                table: "CasiIncidentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FechaBbs",
                table: "Bbss",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
