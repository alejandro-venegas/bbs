using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class BbsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bbss",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FechaBbs = table.Column<string>(nullable: true),
                    ObservadorId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    ComportamientoId = table.Column<int>(nullable: false),
                    TipoObservadoId = table.Column<int>(nullable: false),
                    TipoComportamientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bbss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bbss_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bbss_Comportamientos_ComportamientoId",
                        column: x => x.ComportamientoId,
                        principalTable: "Comportamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bbss_Colaboradores_ObservadorId",
                        column: x => x.ObservadorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bbss_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bbss_TipoComportamientos_TipoComportamientoId",
                        column: x => x.TipoComportamientoId,
                        principalTable: "TipoComportamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bbss_TipoObservados_TipoObservadoId",
                        column: x => x.TipoObservadoId,
                        principalTable: "TipoObservados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_AreaId",
                table: "Bbss",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_ComportamientoId",
                table: "Bbss",
                column: "ComportamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_ObservadorId",
                table: "Bbss",
                column: "ObservadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_ProcesoId",
                table: "Bbss",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_TipoComportamientoId",
                table: "Bbss",
                column: "TipoComportamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bbss_TipoObservadoId",
                table: "Bbss",
                column: "TipoObservadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bbss");
        }
    }
}
