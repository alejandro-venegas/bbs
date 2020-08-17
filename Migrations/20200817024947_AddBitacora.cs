using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class AddBitacora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    DescripcionBitacora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vistas",
                columns: new[] { "Id", "Nombre", "Url" },
                values: new object[] { (byte)12, "Bitácora", "/mantenimiento/bitacora" });

            migrationBuilder.InsertData(
                table: "RolVistas",
                columns: new[] { "RolId", "VistaId", "Escritura" },
                values: new object[] { 1, (byte)12, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DeleteData(
                table: "RolVistas",
                keyColumns: new[] { "RolId", "VistaId" },
                keyValues: new object[] { 1, (byte)12 });

            migrationBuilder.DeleteData(
                table: "Vistas",
                keyColumn: "Id",
                keyValue: (byte)12);
        }
    }
}
