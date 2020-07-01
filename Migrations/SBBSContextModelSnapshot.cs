﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bbs.Models;

namespace bbs_project.Migrations
{
    [DbContext(typeof(SBBSContext))]
    partial class SBBSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bbs.Models.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("bbs.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("bbs.Models.Bbs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("ComportamientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ObservadorId")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoComportamientoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoObservadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ComportamientoId");

                    b.HasIndex("ObservadorId");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("TipoComportamientoId");

                    b.HasIndex("TipoObservadoId");

                    b.ToTable("Bbss");
                });

            modelBuilder.Entity("bbs.Models.CasiIncidente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CasualidadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("JornadaId")
                        .HasColumnType("int");

                    b.Property<string>("Observado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int>("RiesgoId")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CasualidadId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("JornadaId");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("RiesgoId");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("TurnoId");

                    b.ToTable("CasiIncidentes");
                });

            modelBuilder.Entity("bbs.Models.Casualidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Casualidades");
                });

            modelBuilder.Entity("bbs.Models.CausaBasica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("CausaBasicas");
                });

            modelBuilder.Entity("bbs.Models.CausaInmediata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("CausaInmediatas");
                });

            modelBuilder.Entity("bbs.Models.Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Clasificaciones");
                });

            modelBuilder.Entity("bbs.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("bbs.Models.Comportamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Comportamientos");
                });

            modelBuilder.Entity("bbs.Models.CondicionInsegura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("FactorRiesgoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IndicadorRiesgoId")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("FactorRiesgoId");

                    b.HasIndex("IndicadorRiesgoId");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("CondicionInseguras");
                });

            modelBuilder.Entity("bbs.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.HasIndex("GerenteId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("bbs.Models.Efecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Efectos");
                });

            modelBuilder.Entity("bbs.Models.FactorRiesgo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("FactorRiesgos");
                });

            modelBuilder.Entity("bbs.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("bbs.Models.Incidente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CausaBasicaId")
                        .HasColumnType("int");

                    b.Property<int>("CausaInmediataId")
                        .HasColumnType("int");

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("EfectoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("JornadaId")
                        .HasColumnType("int");

                    b.Property<string>("Observado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParteCuerpoId")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int>("RiesgoId")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("AreaId");

                    b.HasIndex("CausaBasicaId");

                    b.HasIndex("CausaInmediataId");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("EfectoId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("JornadaId");

                    b.HasIndex("ParteCuerpoId");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("RiesgoId");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("TurnoId");

                    b.ToTable("Incidentes");
                });

            modelBuilder.Entity("bbs.Models.IndicadorRiesgo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("IndicadorRiesgos");
                });

            modelBuilder.Entity("bbs.Models.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("bbs.Models.Observado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Observados");
                });

            modelBuilder.Entity("bbs.Models.ParteCuerpo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("ParteCuerpos");
                });

            modelBuilder.Entity("bbs.Models.Proceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Procesos");
                });

            modelBuilder.Entity("bbs.Models.Riesgo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IncidenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Riesgos");
                });

            modelBuilder.Entity("bbs.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Administrador del Sistema",
                            Nombre = "Administrador"
                        });
                });

            modelBuilder.Entity("bbs.Models.RolVista", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("VistaId")
                        .HasColumnType("int");

                    b.HasKey("RolId", "VistaId");

                    b.HasIndex("VistaId");

                    b.ToTable("RolVistas");

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            VistaId = 1
                        },
                        new
                        {
                            RolId = 1,
                            VistaId = 2
                        },
                        new
                        {
                            RolId = 1,
                            VistaId = 3
                        },
                        new
                        {
                            RolId = 1,
                            VistaId = 4
                        });
                });

            modelBuilder.Entity("bbs.Models.TipoComportamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("TipoComportamientos");
                });

            modelBuilder.Entity("bbs.Models.TipoObservado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("TipoObservados");
                });

            modelBuilder.Entity("bbs.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("bbs.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("bbs.Models.Vista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Vistas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Reportes"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Graficos"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Administrar"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Mantenimiento"
                        });
                });

            modelBuilder.Entity("bbs.Models.Bbs", b =>
                {
                    b.HasOne("bbs.Models.Area", "Area")
                        .WithMany("Bbss")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Comportamiento", "Comportamiento")
                        .WithMany("Bbss")
                        .HasForeignKey("ComportamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Colaborador", "Observador")
                        .WithMany("Bbss")
                        .HasForeignKey("ObservadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Proceso", "Proceso")
                        .WithMany("Bbss")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.TipoComportamiento", "TipoComportamiento")
                        .WithMany("Bbss")
                        .HasForeignKey("TipoComportamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.TipoObservado", "TipoObservado")
                        .WithMany("Bbss")
                        .HasForeignKey("TipoObservadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bbs.Models.CasiIncidente", b =>
                {
                    b.HasOne("bbs.Models.Area", "Area")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Casualidad", "Casualidad")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("CasualidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Genero", "Genero")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Jornada", "Jornada")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("JornadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Proceso", "Proceso")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Riesgo", "Riesgo")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("RiesgoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Colaborador", "Supervisor")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Turno", "Turno")
                        .WithMany("CasiIncidentes")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bbs.Models.Colaborador", b =>
                {
                    b.HasOne("bbs.Models.Departamento", "Departamento")
                        .WithMany("Colaboradores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("bbs.Models.CondicionInsegura", b =>
                {
                    b.HasOne("bbs.Models.Area", "Area")
                        .WithMany("CondicionInseguras")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.FactorRiesgo", "FactorRiesgo")
                        .WithMany("CondicionInseguras")
                        .HasForeignKey("FactorRiesgoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.IndicadorRiesgo", "IndicadorRiesgo")
                        .WithMany("CondicionInseguras")
                        .HasForeignKey("IndicadorRiesgoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Proceso", "Proceso")
                        .WithMany("CondicionInseguras")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Colaborador", "Supervisor")
                        .WithMany("CondicionInseguras")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bbs.Models.Departamento", b =>
                {
                    b.HasOne("bbs.Models.Colaborador", "Gerente")
                        .WithMany()
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("bbs.Models.Incidente", b =>
                {
                    b.HasOne("bbs.Models.Actividad", "Actividad")
                        .WithMany("Incidentes")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Area", "Area")
                        .WithMany("Incidentes")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.CausaBasica", "CausaBasica")
                        .WithMany("Incidentes")
                        .HasForeignKey("CausaBasicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.CausaInmediata", "CausaInmediata")
                        .WithMany("Incidentes")
                        .HasForeignKey("CausaInmediataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Clasificacion", "Clasificacion")
                        .WithMany("Incidentes")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Efecto", "Efecto")
                        .WithMany("Incidentes")
                        .HasForeignKey("EfectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Genero", "Genero")
                        .WithMany("Incidentes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Jornada", "Jornada")
                        .WithMany("Incidentes")
                        .HasForeignKey("JornadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.ParteCuerpo", "ParteCuerpo")
                        .WithMany("Incidentes")
                        .HasForeignKey("ParteCuerpoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Proceso", "Proceso")
                        .WithMany("Incidentes")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Riesgo", "Riesgo")
                        .WithMany("Incidentes")
                        .HasForeignKey("RiesgoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Colaborador", "Supervisor")
                        .WithMany("Incidentes")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Turno", "Turno")
                        .WithMany("Incidentes")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bbs.Models.RolVista", b =>
                {
                    b.HasOne("bbs.Models.Rol", "Rol")
                        .WithMany("RolVistas")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bbs.Models.Vista", "Vista")
                        .WithMany("RolVistas")
                        .HasForeignKey("VistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
