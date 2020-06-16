using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class CasiIncidente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasiIncidentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCasiIncidente = table.Column<DateTime>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    Observado = table.Column<string>(nullable: true),
                    TurnoId = table.Column<int>(nullable: false),
                    JornadaId = table.Column<int>(nullable: false),
                    RiesgoId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false),
                    CasualidadId = table.Column<int>(nullable: false),
                    DescripcionCasiIncidente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasiIncidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Casualidades_CasualidadId",
                        column: x => x.CasualidadId,
                        principalTable: "Casualidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Jornadas_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Riesgos_RiesgoId",
                        column: x => x.RiesgoId,
                        principalTable: "Riesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Colaboradores_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasiIncidentes_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_AreaId",
                table: "CasiIncidentes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_CasualidadId",
                table: "CasiIncidentes",
                column: "CasualidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_JornadaId",
                table: "CasiIncidentes",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_ProcesoId",
                table: "CasiIncidentes",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_RiesgoId",
                table: "CasiIncidentes",
                column: "RiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_SupervisorId",
                table: "CasiIncidentes",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_TurnoId",
                table: "CasiIncidentes",
                column: "TurnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasiIncidentes");
        }
    }
}
