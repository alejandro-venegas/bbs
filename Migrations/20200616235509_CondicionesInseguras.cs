using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class CondicionesInseguras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicionInseguras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCondicion = table.Column<DateTime>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    FactorRiesgoId = table.Column<int>(nullable: false),
                    IndicadorRiesgoId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionInseguras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CondicionInseguras_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondicionInseguras_FactorRiesgos_FactorRiesgoId",
                        column: x => x.FactorRiesgoId,
                        principalTable: "FactorRiesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondicionInseguras_IndicadorRiesgos_IndicadorRiesgoId",
                        column: x => x.IndicadorRiesgoId,
                        principalTable: "IndicadorRiesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondicionInseguras_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondicionInseguras_Colaboradores_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondicionInseguras_AreaId",
                table: "CondicionInseguras",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionInseguras_FactorRiesgoId",
                table: "CondicionInseguras",
                column: "FactorRiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionInseguras_IndicadorRiesgoId",
                table: "CondicionInseguras",
                column: "IndicadorRiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionInseguras_ProcesoId",
                table: "CondicionInseguras",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionInseguras_SupervisorId",
                table: "CondicionInseguras",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondicionInseguras");
        }
    }
}
