﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace bbs.Models
{
    public partial class SBBSContext : DbContext
    {
        public SBBSContext()
        {
        }

        public SBBSContext(DbContextOptions<SBBSContext> options)
            : base(options)
        {
        }


        public DbSet<Value> Values { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vista> Vistas { get; set; }
        public DbSet<RolVista> RolVistas { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Efecto> Efectos { get; set; }
        public virtual DbSet<FactorRiesgo> FactorRiesgos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<IndicadorRiesgo> IndicadorRiesgos { get; set; }
        public virtual DbSet<Jornada> Jornadas { get; set; }
        public virtual DbSet<Observado> Observados { get; set; }
        public virtual DbSet<ParteCuerpo> ParteCuerpos { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<TipoComportamiento> TipoComportamientos { get; set; }
        public virtual DbSet<TipoObservado> TipoObservados { get; set; }
        public virtual DbSet<CausaInmediata> CausaInmediatas { get; set; }
        public virtual DbSet<CausaBasica> CausaBasicas { get; set; }
        public virtual DbSet<Clasificacion> Clasificaciones { get; set; }

        public virtual DbSet<Actividad> Actividades { get; set; }
        public virtual DbSet<Casualidad> Casualidades { get; set; }
        public virtual DbSet<Comportamiento> Comportamientos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Colaborador> Colaboradores { get; set; }
        public virtual DbSet<Incidente> Incidentes { get; set; }
        public virtual DbSet<CasiIncidente> CasiIncidentes { get; set; }
        public virtual DbSet<Bbs> Bbss { get; set; }

        public virtual DbSet<CondicionInsegura> CondicionInseguras { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Relations
            modelBuilder.Entity<RolVista>()
            .HasKey(rv => new { rv.RolId, rv.VistaId });
            modelBuilder.Entity<RolVista>()
            .HasOne(rv => rv.Rol)
            .WithMany(r => r.RolVistas)
            .HasForeignKey(rv => rv.RolId);
            modelBuilder.Entity<RolVista>()
            .HasOne(rv => rv.Vista)
            .WithMany(v => v.RolVistas)
            .HasForeignKey(rv => rv.VistaId);

            modelBuilder.Entity<Colaborador>()
            .HasOne(c => c.Departamento)
            .WithMany(d => d.Colaboradores)
            .HasForeignKey(c => c.DepartamentoId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Departamento>()
            .HasOne(d => d.Gerente)
            .WithMany()
            .HasForeignKey(d => d.GerenteId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Actividad)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.ActividadId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Area)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.AreaId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Area)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.AreaId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.CausaBasica)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.CausaBasicaId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.CausaInmediata)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.CausaInmediataId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Clasificacion)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.ClasificacionId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Efecto)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.EfectoId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Genero)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.GeneroId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Jornada)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.JornadaId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.ParteCuerpo)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.ParteCuerpoId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Proceso)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.ProcesoId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Riesgo)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.RiesgoId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Supervisor)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.SupervisorId);
            modelBuilder.Entity<Incidente>()
            .HasOne(i => i.Turno)
            .WithMany(a => a.Incidentes)
            .HasForeignKey(i => i.TurnoId);


            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Area)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.AreaId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Area)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.AreaId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Jornada)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.JornadaId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Proceso)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.ProcesoId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Riesgo)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.RiesgoId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Supervisor)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.SupervisorId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Turno)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.TurnoId);
            modelBuilder.Entity<CasiIncidente>()
            .HasOne(i => i.Genero)
            .WithMany(a => a.CasiIncidentes)
            .HasForeignKey(i => i.GeneroId);

            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.Observador)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.ObservadorId);
            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.Area)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.AreaId);
            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.Proceso)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.ProcesoId);
            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.Comportamiento)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.ComportamientoId);
            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.TipoObservado)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.TipoObservadoId);
            modelBuilder.Entity<Bbs>()
            .HasOne(b => b.TipoComportamiento)
            .WithMany(o => o.Bbss)
            .HasForeignKey(bbs => bbs.TipoComportamientoId);

            modelBuilder.Entity<CondicionInsegura>()
            .HasOne(c => c.Area)
            .WithMany(a => a.CondicionInseguras)
            .HasForeignKey(c => c.AreaId);
            modelBuilder.Entity<CondicionInsegura>()
            .HasOne(c => c.Proceso)
            .WithMany(a => a.CondicionInseguras)
            .HasForeignKey(c => c.ProcesoId);
            modelBuilder.Entity<CondicionInsegura>()
            .HasOne(c => c.FactorRiesgo)
            .WithMany(a => a.CondicionInseguras)
            .HasForeignKey(c => c.FactorRiesgoId);
            modelBuilder.Entity<CondicionInsegura>()
            .HasOne(c => c.IndicadorRiesgo)
            .WithMany(a => a.CondicionInseguras)
            .HasForeignKey(c => c.IndicadorRiesgoId);
            modelBuilder.Entity<CondicionInsegura>()
            .HasOne(c => c.Supervisor)
            .WithMany(a => a.CondicionInseguras)
            .HasForeignKey(c => c.SupervisorId);

            modelBuilder.Seed();

        }



    }
}

namespace bbs.Models
{
    static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vista>().HasData(
                new Vista { Id = 1, Nombre = "Reportes", Url = "/reportes/lista" },
                new Vista { Id = 2, Nombre = "Incidente", Url = "/reportes/incidente" },
                new Vista { Id = 3, Nombre = "Casi Incidente", Url = "/reportes/casi-incidente" },
                new Vista { Id = 4, Nombre = "BBS", Url = "/reportes/bbs" },
                new Vista { Id = 5, Nombre = "Condiciones Inseguras", Url = "/reportes/condiciones-inseguras" },
                new Vista { Id = 6, Nombre = "Gráficos", Url = "/graficos" },
                new Vista { Id = 7, Nombre = "Roles", Url = "/administrar/roles" },
                new Vista { Id = 8, Nombre = "Perfiles", Url = "/administrar/perfiles" },
                new Vista { Id = 9, Nombre = "Colaboradores", Url = "/administrar/colaboradores" },
                new Vista { Id = 10, Nombre = "Departamentos", Url = "/administrar/departamentos" },
                new Vista { Id = 11, Nombre = "Formularios", Url = "/mantenimiento/formularios" }

            );

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Superadministrador", Descripcion = "Administrador del Sistema" }
            );

            modelBuilder.Entity<RolVista>().HasData(
                new RolVista { RolId = 1, VistaId = 1, Escritura = true },
                new RolVista { RolId = 1, VistaId = 2, Escritura = true },
                new RolVista { RolId = 1, VistaId = 3, Escritura = true },
                new RolVista { RolId = 1, VistaId = 4, Escritura = true },
                new RolVista { RolId = 1, VistaId = 5, Escritura = true },
                new RolVista { RolId = 1, VistaId = 6, Escritura = true },
                new RolVista { RolId = 1, VistaId = 7, Escritura = true },
                new RolVista { RolId = 1, VistaId = 8, Escritura = true },
                new RolVista { RolId = 1, VistaId = 9, Escritura = true },
                new RolVista { RolId = 1, VistaId = 10, Escritura = true },
                new RolVista { RolId = 1, VistaId = 11, Escritura = true }
            );

            modelBuilder.Entity<Actividad>().HasData(
                new Actividad { Id = 1, Nombre = "Rutinaria" },
                new Actividad { Id = 2, Nombre = "No Rutinaria" }
            );
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Nombre = "Andén de Carga" },
                new Area { Id = 2, Nombre = "Armado de cilindros" },
                new Area { Id = 3, Nombre = "Aséptico" },
                new Area { Id = 4, Nombre = "Banda Subterránea" },
                new Area { Id = 5, Nombre = "Banda de Pelado" },
                new Area { Id = 6, Nombre = "Bodega PT" },
                new Area { Id = 7, Nombre = "Bodega Técnica" },
                new Area { Id = 8, Nombre = "Calderas" },
                new Area { Id = 9, Nombre = "Camerinos" },
                new Area { Id = 10, Nombre = "Centro de acopio" },
                new Area { Id = 11, Nombre = "Comedor" },
                new Area { Id = 12, Nombre = "Concentradores" },
                new Area { Id = 13, Nombre = "Congelado" },
                new Area { Id = 14, Nombre = "Cuarto de Esencia" },
                new Area { Id = 15, Nombre = "Laboratorio Calidad Satélite" },
                new Area { Id = 16, Nombre = "Laboratorio de Microbiología" },
                new Area { Id = 17, Nombre = "Maduradora" },
                new Area { Id = 18, Nombre = "Oficinas" },
                new Area { Id = 19, Nombre = "Patio de Miniobras" },
                new Area { Id = 20, Nombre = "Pilas" },
                new Area { Id = 21, Nombre = "Presterilización" },
                new Area { Id = 22, Nombre = "Puesto 1" },
                new Area { Id = 23, Nombre = "Puesto 2" },
                new Area { Id = 24, Nombre = "Refrigeración" },
                new Area { Id = 25, Nombre = "Servicio médicos" },
                new Area { Id = 26, Nombre = "Taller eléctrico" },
                new Area { Id = 27, Nombre = "Taller mecánico" },
                new Area { Id = 28, Nombre = "Talleres contratistas" },
                new Area { Id = 29, Nombre = "Zonas Externas Varias" },
                new Area { Id = 30, Nombre = "PTAR" },
                new Area { Id = 31, Nombre = "Tanque de Gas LP" },
                new Area { Id = 32, Nombre = "Drinks and Juices" },
                new Area { Id = 33, Nombre = "Planta Piloto" },
                new Area { Id = 34, Nombre = "Baader" },
                new Area { Id = 35, Nombre = "Banda de Pelado" },
                new Area { Id = 36, Nombre = "Bodega de Químicos" },
                new Area { Id = 37, Nombre = "Aduana Principal" },
                new Area { Id = 39, Nombre = "Fincas" },
                new Area { Id = 40, Nombre = "Laboratorio de Calidad" },
                new Area { Id = 41, Nombre = "Laboratorio GI" },
                new Area { Id = 42, Nombre = "Mantenimiento" },
                new Area { Id = 43, Nombre = "Presty" },
                new Area { Id = 44, Nombre = "Edificio Finanzas" },
                new Area { Id = 45, Nombre = "Entretecho Manufactura" },
                new Area { Id = 46, Nombre = "Sala de Capacitación" },
                new Area { Id = 47, Nombre = "Taller" },
                new Area { Id = 48, Nombre = "Tanque de Búnker" },
                new Area { Id = 49, Nombre = "Agrícola" },
                new Area { Id = 50, Nombre = "Cámaras de refrigeración" },
                new Area { Id = 51, Nombre = "Pilas de patio de maniobras" }
            );

            modelBuilder.Entity<Casualidad>().HasData(
                new Casualidad { Id = 1, Nombre = "Acto Inseguro" },
                new Casualidad { Id = 2, Nombre = "Condición Insegura" },
                new Casualidad { Id = 3, Nombre = "Manipulación de sustancias químicas" },
                new Casualidad { Id = 4, Nombre = "No seguimiento de procedimientos" },
                new Casualidad { Id = 5, Nombre = "No uso de EPP" },
                new Casualidad { Id = 6, Nombre = "Posturas y manejo de cargas inadecuadas" },
                new Casualidad { Id = 7, Nombre = "Incidente Ambiental" }
            );

            modelBuilder.Entity<CausaBasica>().HasData(
                new CausaBasica { Id = 1, Nombre = "Acto Inseguro" },
                new CausaBasica { Id = 2, Nombre = "Condición Insegura" },
                new CausaBasica { Id = 3, Nombre = "Práctica ambiental subestándar" },
                new CausaBasica { Id = 4, Nombre = "Condición ambiental subestándar" },
                new CausaBasica { Id = 5, Nombre = "Condición Insegura/ambiental subestándar" }
            );

            modelBuilder.Entity<CausaInmediata>().HasData(
                 new CausaInmediata { Id = 1, Nombre = "Incumplimiento de procedimientos" },
                new CausaInmediata { Id = 2, Nombre = "No uso de EPP" },
                new CausaInmediata { Id = 3, Nombre = "Uso inadecuado de sustancias químicas" },
                new CausaInmediata { Id = 4, Nombre = "Posturas y manejo de cargas inadecuadas" },
                new CausaInmediata { Id = 5, Nombre = "Herramientas/Equipo en mal estado" },
                new CausaInmediata { Id = 6, Nombre = "Nivel de ruido ambiental" },
                new CausaInmediata { Id = 7, Nombre = "Atmósfera inflamable o explosiva" },
                new CausaInmediata { Id = 8, Nombre = "Deficiencia o ausencia de señalización" },
                new CausaInmediata { Id = 9, Nombre = "Deficiencia o ausencia de EPP" },
                new CausaInmediata { Id = 10, Nombre = "Deficiencia o ausencia de elementos de protección de (falta)" },
                new CausaInmediata { Id = 11, Nombre = "Inherentes a materias primas o sustancia" },
                new CausaInmediata { Id = 12, Nombre = "Inconfort térmico" },
                new CausaInmediata { Id = 13, Nombre = "Insuficiente nivel de iluminación" },
                new CausaInmediata { Id = 14, Nombre = "Agentes biólogicos" },
                new CausaInmediata { Id = 15, Nombre = "Factores humanos" },
                new CausaInmediata { Id = 16, Nombre = "Deficiencia o ausencia de mantenimiento de equipos/máquinas (falta)" },
                new CausaInmediata { Id = 17, Nombre = "Insuficiente sectorización de áreas de riesgo" },
                new CausaInmediata { Id = 18, Nombre = "Contacto con sustancias químicas" },
                new CausaInmediata { Id = 19, Nombre = "Consumo irracional de agua" },
                new CausaInmediata { Id = 20, Nombre = "Consumo irracional de energía" },
                new CausaInmediata { Id = 21, Nombre = "Incorrecta separación de desechos" },
                new CausaInmediata { Id = 22, Nombre = "Incorrecto manejo de desechos peligrosos" }
            );

            modelBuilder.Entity<Clasificacion>().HasData(
                new Clasificacion { Id = 1, Nombre = "Lesión Menor" },
                new Clasificacion { Id = 2, Nombre = "Primeros Auxilios" },
                new Clasificacion { Id = 3, Nombre = "Registrable con Restricción" },
                new Clasificacion { Id = 4, Nombre = "Lesión con Pérdida de Tiempo" },
                new Clasificacion { Id = 5, Nombre = "Tratamiento Médico" },
                new Clasificacion { Id = 6, Nombre = "Fatalidad" },
                new Clasificacion { Id = 7, Nombre = "Enfermedad con restricción" },
                new Clasificacion { Id = 8, Nombre = "Enfermedad con días pérdidos" },
                new Clasificacion { Id = 9, Nombre = "Enfermedad lesión menor" },
                new Clasificacion { Id = 10, Nombre = "Incidente Ambiental" },
                new Clasificacion { Id = 11, Nombre = "Lesión Irreversible" }
            );

            modelBuilder.Entity<Comportamiento>().HasData(
                new Comportamiento { Id = 1, Nombre = "Uso del celular" },
                new Comportamiento { Id = 2, Nombre = "Uso de pasamanos" },
                new Comportamiento { Id = 3, Nombre = "Uso de EPP " },
                new Comportamiento { Id = 4, Nombre = "Manejo defensivo vehicular" },
                new Comportamiento { Id = 5, Nombre = "Respeto de la velocidad máxima" },
                new Comportamiento { Id = 6, Nombre = "Uso racional del agua" },
                new Comportamiento { Id = 7, Nombre = "Uso racional de energía" },
                new Comportamiento { Id = 8, Nombre = "Separación de desechos" },
                new Comportamiento { Id = 9, Nombre = "Uso de químicos" },
                new Comportamiento { Id = 10, Nombre = "Uso de montacargas" },
                new Comportamiento { Id = 11, Nombre = "Uso de hidrolavadora" },
                new Comportamiento { Id = 12, Nombre = "Trabajos de alturas" },
                new Comportamiento { Id = 13, Nombre = "Trabajos en calientes" },
                new Comportamiento { Id = 14, Nombre = "Trabajos en espacios confinados (pd)" },
                new Comportamiento { Id = 15, Nombre = "Trabajos en energías peligrosas" },
                new Comportamiento { Id = 16, Nombre = "Levantamiento de cargas" },
                new Comportamiento { Id = 17, Nombre = "Posturas incómodas" },
                new Comportamiento { Id = 18, Nombre = "Pausas activas" },
                new Comportamiento { Id = 19, Nombre = "Caminar, saltar, correr" },
                new Comportamiento { Id = 20, Nombre = "Respeto de las señalizaciones" },
                new Comportamiento { Id = 21, Nombre = "Uso de herramientas manuales" },
                new Comportamiento { Id = 22, Nombre = "Uso de herramientas eléctricas" },
                new Comportamiento { Id = 23, Nombre = "Uso de herramientas mecánicas" },
                new Comportamiento { Id = 24, Nombre = "Orden y limpieza" },
                new Comportamiento { Id = 25, Nombre = "Uso de escaleras" },
                new Comportamiento { Id = 26, Nombre = "Obstrucción de pasillos" },
                new Comportamiento { Id = 27, Nombre = "Aplicación de regla de 3 metros" },
                new Comportamiento { Id = 28, Nombre = "Código de vestimenta" },
                new Comportamiento { Id = 29, Nombre = "Sobre esfuerzos físicos" }
            );

            modelBuilder.Entity<Efecto>().HasData(
                new Efecto { Id = 1, Nombre = "Seguridad" },
                new Efecto { Id = 2, Nombre = "Ambiente" }
            );

            modelBuilder.Entity<FactorRiesgo>().HasData(
                new Efecto { Id = 1, Nombre = "Físicos" },
                new Efecto { Id = 2, Nombre = "Químicos" },
                new Efecto { Id = 3, Nombre = "Biológicos" },
                new Efecto { Id = 4, Nombre = "Ergonómicos" },
                new Efecto { Id = 5, Nombre = "Mecánicos" },
                new Efecto { Id = 6, Nombre = "Infraestructura y Entorno" }
            );

            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Masculino" },
                new Genero { Id = 2, Nombre = "Femenino" }
            );

            modelBuilder.Entity<Jornada>().HasData(
                new Jornada { Id = 1, Nombre = "25% < J < 100%" },
                new Jornada { Id = 2, Nombre = "50% < J < 100%" },
                new Jornada { Id = 3, Nombre = "75% < J < 100%" }
            );

            modelBuilder.Entity<ParteCuerpo>().HasData(
                new ParteCuerpo { Id = 1, Nombre = "Antebrazo Derecho" },
                new ParteCuerpo { Id = 2, Nombre = "Antebrazo Izquierdo" },
                new ParteCuerpo { Id = 3, Nombre = "Brazo Derecho" },
                new ParteCuerpo { Id = 4, Nombre = "Brazo Izquierdo" },
                new ParteCuerpo { Id = 5, Nombre = "Codo Derecho" },
                new ParteCuerpo { Id = 6, Nombre = "Codo Izquierdo" },
                new ParteCuerpo { Id = 7, Nombre = "Dedos de la Mano Derecha" },
                new ParteCuerpo { Id = 8, Nombre = "Dedos de la Mano Izquierda" },
                new ParteCuerpo { Id = 9, Nombre = "Espalda" },
                new ParteCuerpo { Id = 10, Nombre = "Hombro Derecho" },
                new ParteCuerpo { Id = 11, Nombre = "Hombro Izquierdo" },
                new ParteCuerpo { Id = 12, Nombre = "Mano Derecha" },
                new ParteCuerpo { Id = 13, Nombre = "Mano Izquierda" },
                new ParteCuerpo { Id = 14, Nombre = "Pie Derecho" },
                new ParteCuerpo { Id = 15, Nombre = "Pie Izquierdo" },
                new ParteCuerpo { Id = 16, Nombre = "Pierna Izquierda" },
                new ParteCuerpo { Id = 17, Nombre = "Pierda Derecha" },
                new ParteCuerpo { Id = 18, Nombre = "Rodilla Derecha" },
                new ParteCuerpo { Id = 19, Nombre = "Rodilla Izquierda" },
                new ParteCuerpo { Id = 20, Nombre = "Tórax" },
                new ParteCuerpo { Id = 21, Nombre = "Cabeza" },
                new ParteCuerpo { Id = 22, Nombre = "Ojo Derecho" },
                new ParteCuerpo { Id = 23, Nombre = "Ojo Izquierda" },
                new ParteCuerpo { Id = 24, Nombre = "Cara" },
                new ParteCuerpo { Id = 25, Nombre = "Nariz" },
                new ParteCuerpo { Id = 26, Nombre = "Glúteo Derecho" },
                new ParteCuerpo { Id = 27, Nombre = "Glúteo Izquierdo" },
                new ParteCuerpo { Id = 28, Nombre = "Oreja Izquierda" },
                new ParteCuerpo { Id = 29, Nombre = "Oreja Derecha" },
                new ParteCuerpo { Id = 30, Nombre = "Ceja Izquierda" },
                new ParteCuerpo { Id = 31, Nombre = "Ceja Derecha" },
                new ParteCuerpo { Id = 32, Nombre = "Tobillo Derecho" },
                new ParteCuerpo { Id = 33, Nombre = "Tobillo Izquierdo" },
                new ParteCuerpo { Id = 34, Nombre = "Dentadura" },
                new ParteCuerpo { Id = 35, Nombre = "Politraumatismo" }
        );

            modelBuilder.Entity<Proceso>().HasData(
                new Proceso { Id = 1, Nombre = "Agrícola" },
                new Proceso { Id = 2, Nombre = "Calidad" },
                new Proceso { Id = 3, Nombre = "Comercial" },
                new Proceso { Id = 4, Nombre = "Contratistas" },
                new Proceso { Id = 5, Nombre = "Exportaciones" },
                new Proceso { Id = 6, Nombre = "Finanzas & Costos" },
                new Proceso { Id = 7, Nombre = "Gerencia" },
                new Proceso { Id = 8, Nombre = "GIS" },
                new Proceso { Id = 9, Nombre = "I&D" },
                new Proceso { Id = 10, Nombre = "IP" },
                new Proceso { Id = 11, Nombre = "Maduradora" },
                new Proceso { Id = 12, Nombre = "Ingeniería" },
                new Proceso { Id = 13, Nombre = "Planning" },
                new Proceso { Id = 14, Nombre = "Producción" },
                new Proceso { Id = 15, Nombre = "RRHH" },
                new Proceso { Id = 16, Nombre = "SHE" },
                new Proceso { Id = 17, Nombre = "SUPPLY" },
                new Proceso { Id = 18, Nombre = "IT" },
                new Proceso { Id = 19, Nombre = "Compras" },
                new Proceso { Id = 20, Nombre = "Operaciones" },
                new Proceso { Id = 21, Nombre = "Bodega" },
                new Proceso { Id = 22, Nombre = "Manufactura" },
                new Proceso { Id = 23, Nombre = "PTAR" }
            );

            modelBuilder.Entity<Riesgo>().HasData(
                new Riesgo { Id = 1, Nombre = "Bajo" },
                new Riesgo { Id = 2, Nombre = "Medio" },
                new Riesgo { Id = 3, Nombre = "Alto" }
            );

            modelBuilder.Entity<TipoComportamiento>().HasData(
                new Riesgo { Id = 1, Nombre = "Seguro" },
                new Riesgo { Id = 2, Nombre = "Inseguro" }
            );
            modelBuilder.Entity<TipoObservado>().HasData(
                new TipoObservado { Id = 1, Nombre = "Paradise Ingredients" },
                new TipoObservado { Id = 2, Nombre = "Visitantes" },
                new TipoObservado { Id = 3, Nombre = "Contratistas" },
                new TipoObservado { Id = 4, Nombre = "Transportistas" },
                new TipoObservado { Id = 5, Nombre = "Tercerizado" }
            );
            modelBuilder.Entity<Turno>().HasData(
                new Turno { Id = 1, Nombre = "1" },
                new Turno { Id = 2, Nombre = "2" },
                new Turno { Id = 3, Nombre = "3" },
                new Turno { Id = 4, Nombre = "Administrativo" },
                new Turno { Id = 5, Nombre = "Jornadas especiales" }
            );


        }

    }
}