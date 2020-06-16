using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class DepartamentosFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Departmentos_DepartamentoId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Departmentos_Colaboradores_GerenteId",
                table: "Departmentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departmentos",
                table: "Departmentos");

            migrationBuilder.RenameTable(
                name: "Departmentos",
                newName: "Departamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Departmentos_GerenteId",
                table: "Departamentos",
                newName: "IX_Departamentos_GerenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Departamentos_DepartamentoId",
                table: "Colaboradores",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Colaboradores_GerenteId",
                table: "Departamentos",
                column: "GerenteId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Departamentos_DepartamentoId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Colaboradores_GerenteId",
                table: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                newName: "Departmentos");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_GerenteId",
                table: "Departmentos",
                newName: "IX_Departmentos_GerenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departmentos",
                table: "Departmentos",
                column: "Id");

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
    }
}
