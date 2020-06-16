using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class Incidentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Actividades_ActividadId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Areas_AreaId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_CausaBasicas_CausaBasicaId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_CausaInmediatas_CausaInmediataId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Clasificaciones_ClasificacionId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Efectos_EfectoId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Generos_GeneroId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Jornadas_JornadaId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_ParteCuerpos_ParteCuerpoId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Procesos_ProcesoId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Riesgos_RiesgoId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Colaboradores_SupervisorId",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Turnos_TurnoId",
                table: "Incidente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidente",
                table: "Incidente");

            migrationBuilder.RenameTable(
                name: "Incidente",
                newName: "Incidentes");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_TurnoId",
                table: "Incidentes",
                newName: "IX_Incidentes_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_SupervisorId",
                table: "Incidentes",
                newName: "IX_Incidentes_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_RiesgoId",
                table: "Incidentes",
                newName: "IX_Incidentes_RiesgoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_ProcesoId",
                table: "Incidentes",
                newName: "IX_Incidentes_ProcesoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_ParteCuerpoId",
                table: "Incidentes",
                newName: "IX_Incidentes_ParteCuerpoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_JornadaId",
                table: "Incidentes",
                newName: "IX_Incidentes_JornadaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_GeneroId",
                table: "Incidentes",
                newName: "IX_Incidentes_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_EfectoId",
                table: "Incidentes",
                newName: "IX_Incidentes_EfectoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_ClasificacionId",
                table: "Incidentes",
                newName: "IX_Incidentes_ClasificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_CausaInmediataId",
                table: "Incidentes",
                newName: "IX_Incidentes_CausaInmediataId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_CausaBasicaId",
                table: "Incidentes",
                newName: "IX_Incidentes_CausaBasicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_AreaId",
                table: "Incidentes",
                newName: "IX_Incidentes_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidente_ActividadId",
                table: "Incidentes",
                newName: "IX_Incidentes_ActividadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidentes",
                table: "Incidentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Actividades_ActividadId",
                table: "Incidentes",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Areas_AreaId",
                table: "Incidentes",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_CausaBasicas_CausaBasicaId",
                table: "Incidentes",
                column: "CausaBasicaId",
                principalTable: "CausaBasicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_CausaInmediatas_CausaInmediataId",
                table: "Incidentes",
                column: "CausaInmediataId",
                principalTable: "CausaInmediatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Clasificaciones_ClasificacionId",
                table: "Incidentes",
                column: "ClasificacionId",
                principalTable: "Clasificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Efectos_EfectoId",
                table: "Incidentes",
                column: "EfectoId",
                principalTable: "Efectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Generos_GeneroId",
                table: "Incidentes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Jornadas_JornadaId",
                table: "Incidentes",
                column: "JornadaId",
                principalTable: "Jornadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_ParteCuerpos_ParteCuerpoId",
                table: "Incidentes",
                column: "ParteCuerpoId",
                principalTable: "ParteCuerpos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Procesos_ProcesoId",
                table: "Incidentes",
                column: "ProcesoId",
                principalTable: "Procesos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Riesgos_RiesgoId",
                table: "Incidentes",
                column: "RiesgoId",
                principalTable: "Riesgos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Colaboradores_SupervisorId",
                table: "Incidentes",
                column: "SupervisorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Turnos_TurnoId",
                table: "Incidentes",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Actividades_ActividadId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Areas_AreaId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_CausaBasicas_CausaBasicaId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_CausaInmediatas_CausaInmediataId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Clasificaciones_ClasificacionId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Efectos_EfectoId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Generos_GeneroId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Jornadas_JornadaId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_ParteCuerpos_ParteCuerpoId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Procesos_ProcesoId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Riesgos_RiesgoId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Colaboradores_SupervisorId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Turnos_TurnoId",
                table: "Incidentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidentes",
                table: "Incidentes");

            migrationBuilder.RenameTable(
                name: "Incidentes",
                newName: "Incidente");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_TurnoId",
                table: "Incidente",
                newName: "IX_Incidente_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_SupervisorId",
                table: "Incidente",
                newName: "IX_Incidente_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_RiesgoId",
                table: "Incidente",
                newName: "IX_Incidente_RiesgoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_ProcesoId",
                table: "Incidente",
                newName: "IX_Incidente_ProcesoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_ParteCuerpoId",
                table: "Incidente",
                newName: "IX_Incidente_ParteCuerpoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_JornadaId",
                table: "Incidente",
                newName: "IX_Incidente_JornadaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_GeneroId",
                table: "Incidente",
                newName: "IX_Incidente_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_EfectoId",
                table: "Incidente",
                newName: "IX_Incidente_EfectoId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_ClasificacionId",
                table: "Incidente",
                newName: "IX_Incidente_ClasificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_CausaInmediataId",
                table: "Incidente",
                newName: "IX_Incidente_CausaInmediataId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_CausaBasicaId",
                table: "Incidente",
                newName: "IX_Incidente_CausaBasicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_AreaId",
                table: "Incidente",
                newName: "IX_Incidente_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidentes_ActividadId",
                table: "Incidente",
                newName: "IX_Incidente_ActividadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidente",
                table: "Incidente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Actividades_ActividadId",
                table: "Incidente",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Areas_AreaId",
                table: "Incidente",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_CausaBasicas_CausaBasicaId",
                table: "Incidente",
                column: "CausaBasicaId",
                principalTable: "CausaBasicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_CausaInmediatas_CausaInmediataId",
                table: "Incidente",
                column: "CausaInmediataId",
                principalTable: "CausaInmediatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Clasificaciones_ClasificacionId",
                table: "Incidente",
                column: "ClasificacionId",
                principalTable: "Clasificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Efectos_EfectoId",
                table: "Incidente",
                column: "EfectoId",
                principalTable: "Efectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Generos_GeneroId",
                table: "Incidente",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Jornadas_JornadaId",
                table: "Incidente",
                column: "JornadaId",
                principalTable: "Jornadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_ParteCuerpos_ParteCuerpoId",
                table: "Incidente",
                column: "ParteCuerpoId",
                principalTable: "ParteCuerpos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Procesos_ProcesoId",
                table: "Incidente",
                column: "ProcesoId",
                principalTable: "Procesos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Riesgos_RiesgoId",
                table: "Incidente",
                column: "RiesgoId",
                principalTable: "Riesgos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Colaboradores_SupervisorId",
                table: "Incidente",
                column: "SupervisorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Turnos_TurnoId",
                table: "Incidente",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
