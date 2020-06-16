using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class AddIncidente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncidenteId",
                table: "Riesgos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Incidente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIncidente = table.Column<DateTime>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    Observado = table.Column<string>(nullable: true),
                    GeneroId = table.Column<int>(nullable: false),
                    TurnoId = table.Column<int>(nullable: false),
                    JornadaId = table.Column<int>(nullable: false),
                    EfectoId = table.Column<int>(nullable: false),
                    ClasificacionId = table.Column<int>(nullable: false),
                    ActividadId = table.Column<int>(nullable: false),
                    RiesgoId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false),
                    CausaBasicaId = table.Column<int>(nullable: false),
                    CausaInmediataId = table.Column<int>(nullable: false),
                    ParteCuerpoId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidente_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_CausaBasicas_CausaBasicaId",
                        column: x => x.CausaBasicaId,
                        principalTable: "CausaBasicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_CausaInmediatas_CausaInmediataId",
                        column: x => x.CausaInmediataId,
                        principalTable: "CausaInmediatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Clasificaciones_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Efectos_EfectoId",
                        column: x => x.EfectoId,
                        principalTable: "Efectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Jornadas_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_ParteCuerpos_ParteCuerpoId",
                        column: x => x.ParteCuerpoId,
                        principalTable: "ParteCuerpos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Riesgos_RiesgoId",
                        column: x => x.RiesgoId,
                        principalTable: "Riesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Colaboradores_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_ActividadId",
                table: "Incidente",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_AreaId",
                table: "Incidente",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_CausaBasicaId",
                table: "Incidente",
                column: "CausaBasicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_CausaInmediataId",
                table: "Incidente",
                column: "CausaInmediataId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_ClasificacionId",
                table: "Incidente",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_EfectoId",
                table: "Incidente",
                column: "EfectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_GeneroId",
                table: "Incidente",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_JornadaId",
                table: "Incidente",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_ParteCuerpoId",
                table: "Incidente",
                column: "ParteCuerpoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_ProcesoId",
                table: "Incidente",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_RiesgoId",
                table: "Incidente",
                column: "RiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_SupervisorId",
                table: "Incidente",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_TurnoId",
                table: "Incidente",
                column: "TurnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidente");

            migrationBuilder.DropColumn(
                name: "IncidenteId",
                table: "Riesgos");
        }
    }
}
