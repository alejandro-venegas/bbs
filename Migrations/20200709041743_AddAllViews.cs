using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class AddAllViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casualidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
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
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
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
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
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
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
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
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comportamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Efectos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorRiesgos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorRiesgos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorRiesgos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorRiesgos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Observados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParteCuerpos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteCuerpos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Riesgos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    IncidenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riesgos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComportamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComportamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoObservados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoObservados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vistas",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false),
                    Url = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolVistas",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false),
                    VistaId = table.Column<byte>(nullable: false),
                    Escritura = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolVistas", x => new { x.RolId, x.VistaId });
                    table.ForeignKey(
                        name: "FK_RolVistas_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolVistas_Vistas_VistaId",
                        column: x => x.VistaId,
                        principalTable: "Vistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    Observado = table.Column<string>(nullable: false),
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
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidentes_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_CausaBasicas_CausaBasicaId",
                        column: x => x.CausaBasicaId,
                        principalTable: "CausaBasicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_CausaInmediatas_CausaInmediataId",
                        column: x => x.CausaInmediataId,
                        principalTable: "CausaInmediatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Clasificaciones_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Efectos_EfectoId",
                        column: x => x.EfectoId,
                        principalTable: "Efectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Jornadas_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_ParteCuerpos_ParteCuerpoId",
                        column: x => x.ParteCuerpoId,
                        principalTable: "ParteCuerpos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Riesgos_RiesgoId",
                        column: x => x.RiesgoId,
                        principalTable: "Riesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bbss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CasiIncidentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    Observado = table.Column<string>(nullable: false),
                    TurnoId = table.Column<int>(nullable: false),
                    JornadaId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false),
                    RiesgoId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false),
                    CasualidadId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
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
                        name: "FK_CasiIncidentes_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
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
                        name: "FK_CasiIncidentes_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondicionInseguras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GerenteId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Puesto = table.Column<string>(type: "varchar(35)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1, "Administrador del Sistema", "Superadministrador" });

            migrationBuilder.InsertData(
                table: "Vistas",
                columns: new[] { "Id", "Nombre", "Url" },
                values: new object[,]
                {
                    { (byte)1, "Reportes", "/reportes/lista" },
                    { (byte)2, "Incidente", "/reportes/incidente" },
                    { (byte)3, "Casi Incidente", "/reportes/casi-incidente" },
                    { (byte)4, "BBS", "/reportes/bbs" },
                    { (byte)5, "Condiciones Inseguras", "/reportes/condiciones-inseguras" },
                    { (byte)6, "Gráficos", "/graficos" },
                    { (byte)7, "Roles", "/administrar/roles" },
                    { (byte)8, "Perfiles", "/administrar/perfiles" },
                    { (byte)9, "Colaboradores", "/administrar/colaboradores" },
                    { (byte)10, "Departamentos", "/administrar/departamentos" },
                    { (byte)11, "Formularios", "/mantenimiento/formularios" }
                });

            migrationBuilder.InsertData(
                table: "RolVistas",
                columns: new[] { "RolId", "VistaId", "Escritura" },
                values: new object[,]
                {
                    { 1, (byte)1, true },
                    { 1, (byte)2, true },
                    { 1, (byte)3, true },
                    { 1, (byte)4, true },
                    { 1, (byte)5, true },
                    { 1, (byte)6, true },
                    { 1, (byte)7, true },
                    { 1, (byte)8, true },
                    { 1, (byte)9, true },
                    { 1, (byte)10, true },
                    { 1, (byte)11, true }
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

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_AreaId",
                table: "CasiIncidentes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_CasualidadId",
                table: "CasiIncidentes",
                column: "CasualidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CasiIncidentes_GeneroId",
                table: "CasiIncidentes",
                column: "GeneroId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DepartamentoId",
                table: "Colaboradores",
                column: "DepartamentoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_GerenteId",
                table: "Departamentos",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ActividadId",
                table: "Incidentes",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_AreaId",
                table: "Incidentes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_CausaBasicaId",
                table: "Incidentes",
                column: "CausaBasicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_CausaInmediataId",
                table: "Incidentes",
                column: "CausaInmediataId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ClasificacionId",
                table: "Incidentes",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_EfectoId",
                table: "Incidentes",
                column: "EfectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_GeneroId",
                table: "Incidentes",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_JornadaId",
                table: "Incidentes",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ParteCuerpoId",
                table: "Incidentes",
                column: "ParteCuerpoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ProcesoId",
                table: "Incidentes",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_RiesgoId",
                table: "Incidentes",
                column: "RiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_SupervisorId",
                table: "Incidentes",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_TurnoId",
                table: "Incidentes",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolVistas_VistaId",
                table: "RolVistas",
                column: "VistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Colaboradores_SupervisorId",
                table: "Incidentes",
                column: "SupervisorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bbss_Colaboradores_ObservadorId",
                table: "Bbss",
                column: "ObservadorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasiIncidentes_Colaboradores_SupervisorId",
                table: "CasiIncidentes",
                column: "SupervisorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CondicionInseguras_Colaboradores_SupervisorId",
                table: "CondicionInseguras",
                column: "SupervisorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Departamentos_Colaboradores_GerenteId",
                table: "Departamentos");

            migrationBuilder.DropTable(
                name: "Bbss");

            migrationBuilder.DropTable(
                name: "CasiIncidentes");

            migrationBuilder.DropTable(
                name: "CondicionInseguras");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Observados");

            migrationBuilder.DropTable(
                name: "RolVistas");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Comportamientos");

            migrationBuilder.DropTable(
                name: "TipoComportamientos");

            migrationBuilder.DropTable(
                name: "TipoObservados");

            migrationBuilder.DropTable(
                name: "Casualidades");

            migrationBuilder.DropTable(
                name: "FactorRiesgos");

            migrationBuilder.DropTable(
                name: "IndicadorRiesgos");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "CausaBasicas");

            migrationBuilder.DropTable(
                name: "CausaInmediatas");

            migrationBuilder.DropTable(
                name: "Clasificaciones");

            migrationBuilder.DropTable(
                name: "Efectos");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropTable(
                name: "ParteCuerpos");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "Riesgos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Vistas");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
