using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bbs_project.Migrations
{
    public partial class NewMigration : Migration
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
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false)
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
                    CausaBasicaId = table.Column<int>(nullable: false),
                    CausaInmediataId = table.Column<int>(nullable: false),
                    ParteCuerpoId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: false),
                    ColaboradorId = table.Column<int>(nullable: true)
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
                    CasualidadId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    ColaboradorId = table.Column<int>(nullable: true)
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
                    ColaboradorId = table.Column<int>(nullable: true)
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
                table: "Actividades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Rutinaria" },
                    { 2, "No Rutinaria" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 29, "Zonas Externas Varias" },
                    { 30, "PTAR" },
                    { 31, "Tanque de Gas LP" },
                    { 32, "Drinks and Juices" },
                    { 33, "Planta Piloto" },
                    { 34, "Baader" },
                    { 35, "Banda de Pelado" },
                    { 36, "Bodega de Químicos" },
                    { 37, "Aduana Principal" },
                    { 39, "Fincas" },
                    { 40, "Laboratorio de Calidad" },
                    { 41, "Laboratorio GI" },
                    { 42, "Mantenimiento" },
                    { 43, "Presty" },
                    { 44, "Edificio Finanzas" },
                    { 45, "Entretecho Manufactura" },
                    { 46, "Sala de Capacitación" },
                    { 47, "Taller" },
                    { 48, "Tanque de Búnker" },
                    { 49, "Agrícola" },
                    { 50, "Cámaras de refrigeración" },
                    { 51, "Pilas de patio de maniobras" },
                    { 28, "Talleres contratistas" },
                    { 27, "Taller mecánico" },
                    { 26, "Taller eléctrico" },
                    { 12, "Concentradores" },
                    { 3, "Aséptico" },
                    { 4, "Banda Subterránea" },
                    { 5, "Banda de Pelado" },
                    { 6, "Bodega PT" },
                    { 7, "Bodega Técnica" },
                    { 8, "Calderas" },
                    { 9, "Camerinos" },
                    { 10, "Centro de acopio" },
                    { 11, "Comedor" },
                    { 25, "Servicio médicos" },
                    { 2, "Armado de cilindros" },
                    { 13, "Congelado" },
                    { 15, "Laboratorio Calidad Satélite" },
                    { 16, "Laboratorio de Microbiología" },
                    { 17, "Maduradora" },
                    { 18, "Oficinas" },
                    { 19, "Patio de Miniobras" },
                    { 20, "Pilas" },
                    { 21, "Presterilización" },
                    { 22, "Puesto 1" },
                    { 23, "Puesto 2" },
                    { 24, "Refrigeración" },
                    { 14, "Cuarto de Esencia" },
                    { 1, "Andén de Carga" }
                });

            migrationBuilder.InsertData(
                table: "Casualidades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 6, "Posturas y manejo de cargas inadecuadas" },
                    { 7, "Incidente Ambiental" },
                    { 5, "No uso de EPP" },
                    { 4, "No seguimiento de procedimientos" },
                    { 3, "Manipulación de sustancias químicas" },
                    { 2, "Condición Insegura" },
                    { 1, "Acto Inseguro" }
                });

            migrationBuilder.InsertData(
                table: "CausaBasicas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acto Inseguro" },
                    { 2, "Condición Insegura" },
                    { 3, "Práctica ambiental subestándar" },
                    { 4, "Condición ambiental subestándar" },
                    { 5, "Condición Insegura/ambiental subestándar" }
                });

            migrationBuilder.InsertData(
                table: "CausaInmediatas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 14, "Agentes biólogicos" },
                    { 15, "Factores humanos" },
                    { 16, "Deficiencia o ausencia de mantenimiento de equipos/máquinas (falta)" },
                    { 17, "Insuficiente sectorización de áreas de riesgo" },
                    { 22, "Incorrecto manejo de desechos peligrosos" },
                    { 19, "Consumo irracional de agua" },
                    { 21, "Incorrecta separación de desechos" },
                    { 13, "Insuficiente nivel de iluminación" },
                    { 18, "Contacto con sustancias químicas" },
                    { 12, "Inconfort térmico" },
                    { 20, "Consumo irracional de energía" },
                    { 10, "Deficiencia o ausencia de elementos de protección de (falta)" },
                    { 9, "Deficiencia o ausencia de EPP" },
                    { 8, "Deficiencia o ausencia de señalización" },
                    { 7, "Atmósfera inflamable o explosiva" },
                    { 6, "Nivel de ruido ambiental" },
                    { 5, "Herramientas/Equipo en mal estado" },
                    { 4, "Posturas y manejo de cargas inadecuadas" },
                    { 3, "Uso inadecuado de sustancias químicas" },
                    { 2, "No uso de EPP" },
                    { 1, "Incumplimiento de procedimientos" },
                    { 11, "Inherentes a materias primas o sustancia" }
                });

            migrationBuilder.InsertData(
                table: "Clasificaciones",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 11, "Lesión Irreversible" },
                    { 10, "Incidente Ambiental" },
                    { 9, "Enfermedad lesión menor" },
                    { 8, "Enfermedad con días pérdidos" },
                    { 6, "Fatalidad" },
                    { 7, "Enfermedad con restricción" },
                    { 4, "Lesión con Pérdida de Tiempo" },
                    { 3, "Registrable con Restricción" },
                    { 2, "Primeros Auxilios" },
                    { 1, "Lesión Menor" },
                    { 5, "Tratamiento Médico" }
                });

            migrationBuilder.InsertData(
                table: "Comportamientos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 18, "Pausas activas" },
                    { 19, "Caminar, saltar, correr" },
                    { 20, "Respeto de las señalizaciones" },
                    { 21, "Uso de herramientas manuales" },
                    { 22, "Uso de herramientas eléctricas" },
                    { 23, "Uso de herramientas mecánicas" },
                    { 25, "Uso de escaleras" },
                    { 26, "Obstrucción de pasillos" },
                    { 27, "Aplicación de regla de 3 metros" },
                    { 28, "Código de vestimenta" },
                    { 29, "Sobre esfuerzos físicos" },
                    { 16, "Levantamiento de cargas" },
                    { 24, "Orden y limpieza" },
                    { 15, "Trabajos en energías peligrosas" },
                    { 17, "Posturas incómodas" },
                    { 13, "Trabajos en calientes" },
                    { 1, "Uso del celular" },
                    { 2, "Uso de pasamanos" },
                    { 3, "Uso de EPP " },
                    { 4, "Manejo defensivo vehicular" },
                    { 6, "Uso racional del agua" },
                    { 7, "Uso racional de energía" },
                    { 5, "Respeto de la velocidad máxima" },
                    { 9, "Uso de químicos" },
                    { 10, "Uso de montacargas" },
                    { 11, "Uso de hidrolavadora" },
                    { 12, "Trabajos de alturas" },
                    { 14, "Trabajos en espacios confinados (pd)" },
                    { 8, "Separación de desechos" }
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "GerenteId", "Nombre" },
                values: new object[] { 1, null, "Por Definir" });

            migrationBuilder.InsertData(
                table: "Efectos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Seguridad" },
                    { 2, "Ambiente" }
                });

            migrationBuilder.InsertData(
                table: "FactorRiesgos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Mecánicos" },
                    { 4, "Ergonómicos" },
                    { 6, "Infraestructura y Entorno" },
                    { 2, "Químicos" },
                    { 1, "Físicos" },
                    { 3, "Biológicos" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "Jornadas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "25% < J < 100%" },
                    { 2, "50% < J < 100%" },
                    { 3, "75% < J < 100%" }
                });

            migrationBuilder.InsertData(
                table: "ParteCuerpos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 20, "Tórax" },
                    { 21, "Cabeza" },
                    { 22, "Ojo Derecho" },
                    { 23, "Ojo Izquierda" },
                    { 24, "Cara" },
                    { 25, "Nariz" },
                    { 26, "Glúteo Derecho" },
                    { 35, "Politraumatismo" },
                    { 28, "Oreja Izquierda" },
                    { 29, "Oreja Derecha" },
                    { 31, "Ceja Derecha" },
                    { 32, "Tobillo Derecho" },
                    { 33, "Tobillo Izquierdo" },
                    { 34, "Dentadura" },
                    { 19, "Rodilla Izquierda" },
                    { 27, "Glúteo Izquierdo" },
                    { 18, "Rodilla Derecha" },
                    { 30, "Ceja Izquierda" },
                    { 16, "Pierna Izquierda" },
                    { 17, "Pierda Derecha" },
                    { 1, "Antebrazo Derecho" },
                    { 2, "Antebrazo Izquierdo" },
                    { 4, "Brazo Izquierdo" },
                    { 5, "Codo Derecho" },
                    { 6, "Codo Izquierdo" },
                    { 7, "Dedos de la Mano Derecha" },
                    { 3, "Brazo Derecho" },
                    { 9, "Espalda" },
                    { 10, "Hombro Derecho" },
                    { 11, "Hombro Izquierdo" },
                    { 12, "Mano Derecha" },
                    { 13, "Mano Izquierda" },
                    { 14, "Pie Derecho" },
                    { 8, "Dedos de la Mano Izquierda" },
                    { 15, "Pie Izquierdo" }
                });

            migrationBuilder.InsertData(
                table: "Procesos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 14, "Producción" },
                    { 15, "RRHH" },
                    { 16, "SHE" },
                    { 17, "SUPPLY" },
                    { 21, "Bodega" },
                    { 20, "Operaciones" },
                    { 22, "Manufactura" },
                    { 23, "PTAR" },
                    { 13, "Planning" },
                    { 19, "Compras" },
                    { 12, "Ingeniería" },
                    { 18, "IT" },
                    { 10, "IP" },
                    { 11, "Maduradora" },
                    { 2, "Calidad" },
                    { 3, "Comercial" },
                    { 4, "Contratistas" },
                    { 1, "Agrícola" },
                    { 6, "Finanzas & Costos" },
                    { 7, "Gerencia" },
                    { 8, "GIS" },
                    { 9, "I&D" },
                    { 5, "Exportaciones" }
                });

            migrationBuilder.InsertData(
                table: "Riesgos",
                columns: new[] { "Id", "IncidenteId", "Nombre" },
                values: new object[,]
                {
                    { 1, 0, "Bajo" },
                    { 2, 0, "Medio" },
                    { 3, 0, "Alto" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Posee más permisos de edición en los formularios, puede gestionar gráficos y/o reportes de todos los departamentos", "Encargado" },
                    { 2, "Posee permisos de ingreso, gestión de gráficas y/o reportes, puede ceder al Trabajador el acceso al sistema para el ingreso de los formularios", "Gerente" },
                    { 3, "Posee permisos para el ingreso de los formularios", "Trabajador" }
                });

            migrationBuilder.InsertData(
                table: "TipoComportamientos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Seguro" },
                    { 2, "Inseguro" }
                });

            migrationBuilder.InsertData(
                table: "TipoObservados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Tercerizado" },
                    { 4, "Transportistas" },
                    { 1, "Paradise Ingredients" },
                    { 2, "Visitantes" },
                    { 3, "Contratistas" }
                });

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "Administrativo" },
                    { 5, "Jornadas especiales" }
                });

            migrationBuilder.InsertData(
                table: "Vistas",
                columns: new[] { "Id", "Nombre", "Url" },
                values: new object[,]
                {
                    { (byte)9, "Colaboradores", "/administrar/colaboradores" },
                    { (byte)8, "Perfiles", "/administrar/perfiles" },
                    { (byte)7, "Roles", "/administrar/roles" },
                    { (byte)6, "Gráficos", "/graficos" },
                    { (byte)2, "Incidente", "/reportes/incidente" },
                    { (byte)4, "BBS", "/reportes/bbs" },
                    { (byte)3, "Casi Incidente", "/reportes/casi-incidente" },
                    { (byte)1, "Reportes", "/reportes/lista" },
                    { (byte)10, "Departamentos", "/administrar/departamentos" },
                    { (byte)5, "Condiciones Inseguras", "/reportes/condiciones-inseguras" },
                    { (byte)11, "Formularios", "/mantenimiento/formularios" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Apellido", "DepartamentoId", "Nombre", "Puesto" },
                values: new object[,]
                {
                    { 1, "Céspedes", 1, "Alberto", "Por Definir" },
                    { 29, "Koying", 1, "Carlos", "Por Definir" },
                    { 28, "Alvarado", 1, "Nitzi", "Por Definir" },
                    { 26, "Leiva", 1, "Tannia", "Por Definir" },
                    { 25, "Guerrero", 1, "Ronald", "Por Definir" },
                    { 24, "Calderón", 1, "Randall", "Por Definir" },
                    { 23, "Jiménez", 1, "Max", "Por Definir" },
                    { 22, "Vega", 1, "Marco", "Por Definir" },
                    { 21, "Arias", 1, "Marco", "Por Definir" },
                    { 20, "Aguilar", 1, "M", "Por Definir" },
                    { 19, "Rodríguez", 1, "Kenneth", "Por Definir" },
                    { 18, "Robles", 1, "Juan", "Por Definir" },
                    { 17, "Solano", 1, "Jorge", "Por Definir" },
                    { 16, "Jiménez", 1, "Jorge", "Por Definir" },
                    { 27, "Sequeira", 1, "Walter", "Por Definir" },
                    { 14, "Hernández", 1, "Hector", "Por Definir" },
                    { 15, "Durán", 1, "Jimmy", "Por Definir" },
                    { 2, "Blanco", 1, "Alejandro", "Por Definir" },
                    { 4, "Calderón", 1, "Carla", "Por Definir" },
                    { 5, "Brenes", 1, "Carlos", "Por Definir" },
                    { 6, "Durán", 1, "Carlos", "Por Definir" },
                    { 7, "Astua", 1, "Cristina", "Por Definir" },
                    { 3, "Montero", 1, "Alejandro", "Por Definir" },
                    { 9, "Chaves", 1, "Diana", "Por Definir" },
                    { 10, "Sánchez", 1, "Ercik", "Por Definir" },
                    { 11, "Gould", 1, "Esteban", "Por Definir" },
                    { 12, "Ramírez", 1, "Fernando", "Por Definir" },
                    { 8, "Acuña", 1, "Dennis", "Por Definir" },
                    { 13, "Rivera", 1, "Fernando", "Por Definir" }
                });

            migrationBuilder.InsertData(
                table: "RolVistas",
                columns: new[] { "RolId", "VistaId", "Escritura" },
                values: new object[,]
                {
                    { 2, (byte)5, true },
                    { 3, (byte)5, true },
                    { 1, (byte)6, true },
                    { 2, (byte)6, true },
                    { 1, (byte)8, true },
                    { 2, (byte)8, true },
                    { 1, (byte)9, true },
                    { 1, (byte)5, true },
                    { 2, (byte)9, true },
                    { 1, (byte)7, true },
                    { 3, (byte)4, true },
                    { 2, (byte)2, true },
                    { 1, (byte)4, true },
                    { 3, (byte)3, true },
                    { 2, (byte)3, true },
                    { 1, (byte)3, true },
                    { 3, (byte)2, true },
                    { 1, (byte)2, true },
                    { 3, (byte)1, true },
                    { 2, (byte)1, true },
                    { 1, (byte)1, true },
                    { 1, (byte)10, true },
                    { 2, (byte)4, true },
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
                name: "IX_CasiIncidentes_ColaboradorId",
                table: "CasiIncidentes",
                column: "ColaboradorId");

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
                name: "IX_CondicionInseguras_ColaboradorId",
                table: "CondicionInseguras",
                column: "ColaboradorId");

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
                name: "IX_Incidentes_ColaboradorId",
                table: "Incidentes",
                column: "ColaboradorId");

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
                name: "IX_Incidentes_TurnoId",
                table: "Incidentes",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolVistas_VistaId",
                table: "RolVistas",
                column: "VistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Colaboradores_ColaboradorId",
                table: "Incidentes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bbss_Colaboradores_ObservadorId",
                table: "Bbss",
                column: "ObservadorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasiIncidentes_Colaboradores_ColaboradorId",
                table: "CasiIncidentes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CondicionInseguras_Colaboradores_ColaboradorId",
                table: "CondicionInseguras",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
