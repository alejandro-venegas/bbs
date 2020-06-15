using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionRol",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NombreRol",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NombreObservado",
                table: "Observados");

            migrationBuilder.DropColumn(
                name: "NombreIndicadorRiesgo",
                table: "IndicadorRiesgos");

            migrationBuilder.DropColumn(
                name: "NombreGenero",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "NombreFactorRiesgo",
                table: "FactorRiesgos");

            migrationBuilder.RenameColumn(
                name: "NombreVista",
                table: "Vistas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreTurno",
                table: "Turnos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreTipoObservado",
                table: "TipoObservados",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreTipoComportamiento",
                table: "TipoComportamientos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreRiesgo",
                table: "Riesgos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreProceso",
                table: "Procesos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreJornada",
                table: "Jornadas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreEfecto",
                table: "Efectos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreArea",
                table: "Areas",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Observados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "IndicadorRiesgos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Generos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "FactorRiesgos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casualidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casualidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausaBasicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausaBasicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausaInmediatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausaInmediatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clasificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comportamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comportamientos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Administrador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Casualidades");

            migrationBuilder.DropTable(
                name: "CausaBasicas");

            migrationBuilder.DropTable(
                name: "CausaInmediatas");

            migrationBuilder.DropTable(
                name: "Clasificaciones");

            migrationBuilder.DropTable(
                name: "Comportamientos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Observados");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "IndicadorRiesgos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "FactorRiesgos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Vistas",
                newName: "NombreVista");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Turnos",
                newName: "NombreTurno");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "TipoObservados",
                newName: "NombreTipoObservado");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "TipoComportamientos",
                newName: "NombreTipoComportamiento");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Riesgos",
                newName: "NombreRiesgo");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Procesos",
                newName: "NombreProceso");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Jornadas",
                newName: "NombreJornada");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Efectos",
                newName: "NombreEfecto");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Areas",
                newName: "NombreArea");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionRol",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreRol",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreObservado",
                table: "Observados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreIndicadorRiesgo",
                table: "IndicadorRiesgos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreGenero",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreFactorRiesgo",
                table: "FactorRiesgos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "NombreRol",
                value: "Administrador");
        }
    }
}
