using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class DepartamentoColaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Departmentos_DepartamentoId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Departmentos_Colaboradores_GerenteId",
                table: "Departmentos");

            migrationBuilder.AlterColumn<int>(
                name: "GerenteId",
                table: "Departmentos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Colaboradores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Departmentos_DepartamentoId",
                table: "Colaboradores",
                column: "DepartamentoId",
                principalTable: "Departmentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Departmentos_Colaboradores_GerenteId",
                table: "Departmentos",
                column: "GerenteId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Departmentos_DepartamentoId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Departmentos_Colaboradores_GerenteId",
                table: "Departmentos");

            migrationBuilder.AlterColumn<int>(
                name: "GerenteId",
                table: "Departmentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Departmentos_DepartamentoId",
                table: "Colaboradores",
                column: "DepartamentoId",
                principalTable: "Departmentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departmentos_Colaboradores_GerenteId",
                table: "Departmentos",
                column: "GerenteId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
