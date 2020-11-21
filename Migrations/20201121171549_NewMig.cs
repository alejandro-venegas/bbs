using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Bitacora");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Bitacora",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_UsuarioId",
                table: "Bitacora",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacora_Usuarios_UsuarioId",
                table: "Bitacora",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacora_Usuarios_UsuarioId",
                table: "Bitacora");

            migrationBuilder.DropIndex(
                name: "IX_Bitacora_UsuarioId",
                table: "Bitacora");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Bitacora");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Bitacora",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
