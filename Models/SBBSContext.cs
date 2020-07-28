using System;
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
                new Rol { Id = 1, Nombre = "Encargado", Descripcion = "Posee más permisos de edición en los formularios, puede gestionar gráficos y/o reportes de todos los departamentos" },
                new Rol { Id = 2, Nombre = "Gerente", Descripcion = "Posee permisos de ingreso, gestión de gráficas y/o reportes, puede ceder al Trabajador el acceso al sistema para el ingreso de los formularios" },
                new Rol { Id = 3, Nombre = "Trabajador", Descripcion = "Posee permisos para el ingreso de los formularios" }
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
                new RolVista { RolId = 1, VistaId = 11, Escritura = true },
                new RolVista { RolId = 2, VistaId = 1, Escritura = true },
                new RolVista { RolId = 2, VistaId = 2, Escritura = true },
                new RolVista { RolId = 2, VistaId = 3, Escritura = true },
                new RolVista { RolId = 2, VistaId = 4, Escritura = true },
                new RolVista { RolId = 2, VistaId = 5, Escritura = true },
                new RolVista { RolId = 2, VistaId = 6, Escritura = true },
                new RolVista { RolId = 2, VistaId = 8, Escritura = true },
                new RolVista { RolId = 2, VistaId = 9, Escritura = true },
                new RolVista { RolId = 3, VistaId = 1, Escritura = true },
                new RolVista { RolId = 3, VistaId = 2, Escritura = true },
                new RolVista { RolId = 3, VistaId = 3, Escritura = true },
                new RolVista { RolId = 3, VistaId = 4, Escritura = true },
                new RolVista { RolId = 3, VistaId = 5, Escritura = true }

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
                new FactorRiesgo { Id = 1, Nombre = "Físicos" },
                new FactorRiesgo { Id = 2, Nombre = "Químicos" },
                new FactorRiesgo { Id = 3, Nombre = "Biológicos" },
                new FactorRiesgo { Id = 4, Nombre = "Ergonómicos" },
                new FactorRiesgo { Id = 5, Nombre = "Mecánicos" },
                new FactorRiesgo { Id = 6, Nombre = "Infraestructura y Entorno" }
            );


            modelBuilder.Entity<IndicadorRiesgo>().HasData(
                new IndicadorRiesgo { Id = 1, Nombre = "Físicos" },
                new IndicadorRiesgo { Id = 2, Nombre = "Químicos" },
                new IndicadorRiesgo { Id = 3, Nombre = "Biológicos" },
                new IndicadorRiesgo { Id = 4, Nombre = "Ergonómicos" },
                new IndicadorRiesgo { Id = 5, Nombre = "Mecánicos" },
                new IndicadorRiesgo { Id = 6, Nombre = "Infraestructura y Entorno" }
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

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nombre = "Por Definir" }
            );

            modelBuilder.Entity<Colaborador>().HasData(
                new Colaborador { Id = 1, Nombre = "Alberto", Apellido = "Céspedes", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 2, Nombre = "Alejandro", Apellido = "Blanco", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 3, Nombre = "Alejandro", Apellido = "Montero", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 4, Nombre = "Carla", Apellido = "Calderón", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 5, Nombre = "Carlos", Apellido = "Brenes", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 6, Nombre = "Carlos", Apellido = "Durán", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 7, Nombre = "Cristina", Apellido = "Astua", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 8, Nombre = "Dennis", Apellido = "Acuña", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 9, Nombre = "Diana", Apellido = "Chaves", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 10, Nombre = "Ercik", Apellido = "Sánchez", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 11, Nombre = "Esteban", Apellido = "Gould", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 12, Nombre = "Fernando", Apellido = "Ramírez", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 13, Nombre = "Fernando", Apellido = "Rivera", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 14, Nombre = "Hector", Apellido = "Hernández", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 15, Nombre = "Jimmy", Apellido = "Durán", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 16, Nombre = "Jorge", Apellido = "Jiménez", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 17, Nombre = "Jorge", Apellido = "Solano", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 18, Nombre = "Juan", Apellido = "Robles", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 19, Nombre = "Kenneth", Apellido = "Rodríguez", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 20, Nombre = "M", Apellido = "Aguilar", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 21, Nombre = "Marco", Apellido = "Arias", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 22, Nombre = "Marco", Apellido = "Vega", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 23, Nombre = "Max", Apellido = "Jiménez", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 24, Nombre = "Randall", Apellido = "Calderón", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 25, Nombre = "Ronald", Apellido = "Guerrero", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 26, Nombre = "Tannia", Apellido = "Leiva", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 27, Nombre = "Walter", Apellido = "Sequeira", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 28, Nombre = "Nitzi", Apellido = "Alvarado", Puesto = "Por Definir", DepartamentoId = 1 },
                new Colaborador { Id = 29, Nombre = "Carlos", Apellido = "Koying", Puesto = "Por Definir", DepartamentoId = 1 }
            );

            modelBuilder.Entity<Bbs>().HasData(
                new Bbs { Id = 1, Fecha = new DateTime(2020, 01, 07), ObservadorId = 11, AreaId = 35, ProcesoId = 15, ComportamientoId = 5, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 2, Fecha = new DateTime(2020, 01, 18), ObservadorId = 5, AreaId = 44, ProcesoId = 13, ComportamientoId = 26, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 3, Fecha = new DateTime(2020, 01, 23), ObservadorId = 5, AreaId = 3, ProcesoId = 10, ComportamientoId = 6, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 4, Fecha = new DateTime(2020, 02, 02), ObservadorId = 2, AreaId = 37, ProcesoId = 13, ComportamientoId = 24, TipoObservadoId = 2, TipoComportamientoId = 1 },
                new Bbs { Id = 5, Fecha = new DateTime(2020, 02, 12), ObservadorId = 1, AreaId = 10, ProcesoId = 21, ComportamientoId = 21, TipoObservadoId = 2, TipoComportamientoId = 2 },
                new Bbs { Id = 6, Fecha = new DateTime(2020, 02, 27), ObservadorId = 6, AreaId = 44, ProcesoId = 2, ComportamientoId = 29, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 7, Fecha = new DateTime(2020, 03, 05), ObservadorId = 3, AreaId = 22, ProcesoId = 15, ComportamientoId = 25, TipoObservadoId = 2, TipoComportamientoId = 2 },
                new Bbs { Id = 8, Fecha = new DateTime(2020, 03, 06), ObservadorId = 7, AreaId = 48, ProcesoId = 1, ComportamientoId = 29, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 9, Fecha = new DateTime(2020, 03, 20), ObservadorId = 1, AreaId = 9, ProcesoId = 18, ComportamientoId = 19, TipoObservadoId = 2, TipoComportamientoId = 2 },
                new Bbs { Id = 10, Fecha = new DateTime(2020, 03, 25), ObservadorId = 1, AreaId = 26, ProcesoId = 12, ComportamientoId = 11, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 11, Fecha = new DateTime(2020, 04, 02), ObservadorId = 9, AreaId = 13, ProcesoId = 9, ComportamientoId = 17, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 12, Fecha = new DateTime(2020, 04, 09), ObservadorId = 10, AreaId = 32, ProcesoId = 21, ComportamientoId = 1, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 13, Fecha = new DateTime(2020, 04, 16), ObservadorId = 5, AreaId = 22, ProcesoId = 22, ComportamientoId = 27, TipoObservadoId = 2, TipoComportamientoId = 2 },
                new Bbs { Id = 14, Fecha = new DateTime(2020, 04, 21), ObservadorId = 4, AreaId = 36, ProcesoId = 9, ComportamientoId = 9, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 15, Fecha = new DateTime(2020, 04, 30), ObservadorId = 11, AreaId = 13, ProcesoId = 22, ComportamientoId = 26, TipoObservadoId = 4, TipoComportamientoId = 1 },
                new Bbs { Id = 16, Fecha = new DateTime(2020, 05, 04), ObservadorId = 10, AreaId = 29, ProcesoId = 23, ComportamientoId = 22, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 17, Fecha = new DateTime(2020, 05, 17), ObservadorId = 2, AreaId = 19, ProcesoId = 2, ComportamientoId = 18, TipoObservadoId = 3, TipoComportamientoId = 1 },
                new Bbs { Id = 18, Fecha = new DateTime(2020, 05, 19), ObservadorId = 2, AreaId = 46, ProcesoId = 7, ComportamientoId = 28, TipoObservadoId = 5, TipoComportamientoId = 2 },
                new Bbs { Id = 19, Fecha = new DateTime(2020, 05, 31), ObservadorId = 5, AreaId = 25, ProcesoId = 6, ComportamientoId = 11, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 20, Fecha = new DateTime(2020, 06, 10), ObservadorId = 6, AreaId = 16, ProcesoId = 18, ComportamientoId = 9, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 21, Fecha = new DateTime(2020, 06, 25), ObservadorId = 6, AreaId = 35, ProcesoId = 8, ComportamientoId = 7, TipoObservadoId = 2, TipoComportamientoId = 1 },
                new Bbs { Id = 22, Fecha = new DateTime(2020, 06, 29), ObservadorId = 4, AreaId = 46, ProcesoId = 5, ComportamientoId = 27, TipoObservadoId = 2, TipoComportamientoId = 1 },
                new Bbs { Id = 23, Fecha = new DateTime(2020, 06, 30), ObservadorId = 9, AreaId = 1, ProcesoId = 5, ComportamientoId = 3, TipoObservadoId = 2, TipoComportamientoId = 2 },
                new Bbs { Id = 24, Fecha = new DateTime(2020, 07, 03), ObservadorId = 7, AreaId = 44, ProcesoId = 17, ComportamientoId = 26, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 25, Fecha = new DateTime(2020, 07, 08), ObservadorId = 8, AreaId = 6, ProcesoId = 19, ComportamientoId = 9, TipoObservadoId = 1, TipoComportamientoId = 1 },
                new Bbs { Id = 26, Fecha = new DateTime(2020, 07, 16), ObservadorId = 8, AreaId = 49, ProcesoId = 3, ComportamientoId = 21, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 27, Fecha = new DateTime(2020, 07, 24), ObservadorId = 1, AreaId = 37, ProcesoId = 1, ComportamientoId = 29, TipoObservadoId = 5, TipoComportamientoId = 2 },
                new Bbs { Id = 28, Fecha = new DateTime(2020, 07, 25), ObservadorId = 8, AreaId = 22, ProcesoId = 4, ComportamientoId = 4, TipoObservadoId = 1, TipoComportamientoId = 2 },
                new Bbs { Id = 29, Fecha = new DateTime(2020, 07, 27), ObservadorId = 1, AreaId = 2, ProcesoId = 21, ComportamientoId = 2, TipoObservadoId = 3, TipoComportamientoId = 2 },
                new Bbs { Id = 30, Fecha = new DateTime(2020, 07, 28), ObservadorId = 9, AreaId = 9, ProcesoId = 23, ComportamientoId = 21, TipoObservadoId = 1, TipoComportamientoId = 1 }
            );

            modelBuilder.Entity<Incidente>().HasData(
                new Incidente { Id = 1, Fecha = new DateTime(2020, 01, 17), AreaId = 1, ProcesoId = 23, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 2, JornadaId = 1, EfectoId = 2, ClasificacionId = 1, ActividadId = 1, RiesgoId = 1, CausaBasicaId = 2, CausaInmediataId = 2, ParteCuerpoId = 11, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 2, Fecha = new DateTime(2020, 01, 23), AreaId = 11, ProcesoId = 4, Observado = "Alejandro Venegas", GeneroId = 2, TurnoId = 1, JornadaId = 2, EfectoId = 2, ClasificacionId = 5, ActividadId = 2, RiesgoId = 2, CausaBasicaId = 1, CausaInmediataId = 2, ParteCuerpoId = 3, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 3, Fecha = new DateTime(2020, 02, 06), AreaId = 26, ProcesoId = 18, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 4, JornadaId = 2, EfectoId = 2, ClasificacionId = 3, ActividadId = 1, RiesgoId = 3, CausaBasicaId = 4, CausaInmediataId = 5, ParteCuerpoId = 3, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 4, Fecha = new DateTime(2020, 02, 27), AreaId = 36, ProcesoId = 22, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 4, JornadaId = 3, EfectoId = 2, ClasificacionId = 7, ActividadId = 1, RiesgoId = 2, CausaBasicaId = 3, CausaInmediataId = 6, ParteCuerpoId = 7, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 5, Fecha = new DateTime(2020, 03, 25), AreaId = 49, ProcesoId = 19, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 3, JornadaId = 2, EfectoId = 2, ClasificacionId = 3, ActividadId = 1, RiesgoId = 1, CausaBasicaId = 5, CausaInmediataId = 8, ParteCuerpoId = 4, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 6, Fecha = new DateTime(2020, 03, 28), AreaId = 21, ProcesoId = 20, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 3, JornadaId = 1, EfectoId = 2, ClasificacionId = 5, ActividadId = 1, RiesgoId = 2, CausaBasicaId = 1, CausaInmediataId = 15, ParteCuerpoId = 7, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 7, Fecha = new DateTime(2020, 04, 09), AreaId = 48, ProcesoId = 4, Observado = "Alejandro Venegas", GeneroId = 2, TurnoId = 5, JornadaId = 2, EfectoId = 2, ClasificacionId = 8, ActividadId = 1, RiesgoId = 3, CausaBasicaId = 2, CausaInmediataId = 6, ParteCuerpoId = 14, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 8, Fecha = new DateTime(2020, 04, 14), AreaId = 12, ProcesoId = 5, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 1, JornadaId = 2, EfectoId = 1, ClasificacionId = 9, ActividadId = 2, RiesgoId = 1, CausaBasicaId = 3, CausaInmediataId = 16, ParteCuerpoId = 35, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 9, Fecha = new DateTime(2020, 04, 21), AreaId = 50, ProcesoId = 1, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 2, JornadaId = 1, EfectoId = 2, ClasificacionId = 10, ActividadId = 1, RiesgoId = 2, CausaBasicaId = 5, CausaInmediataId = 4, ParteCuerpoId = 22, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 10, Fecha = new DateTime(2020, 05, 23), AreaId = 16, ProcesoId = 4, Observado = "Alejandro Venegas", GeneroId = 2, TurnoId = 4, JornadaId = 1, EfectoId = 2, ClasificacionId = 11, ActividadId = 1, RiesgoId = 3, CausaBasicaId = 2, CausaInmediataId = 12, ParteCuerpoId = 31, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 11, Fecha = new DateTime(2020, 05, 30), AreaId = 23, ProcesoId = 6, Observado = "Alejandro Venegas", GeneroId = 2, TurnoId = 2, JornadaId = 2, EfectoId = 1, ClasificacionId = 2, ActividadId = 2, RiesgoId = 2, CausaBasicaId = 3, CausaInmediataId = 22, ParteCuerpoId = 20, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 12, Fecha = new DateTime(2020, 06, 11), AreaId = 41, ProcesoId = 16, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 2, JornadaId = 3, EfectoId = 1, ClasificacionId = 4, ActividadId = 1, RiesgoId = 2, CausaBasicaId = 5, CausaInmediataId = 20, ParteCuerpoId = 19, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 13, Fecha = new DateTime(2020, 06, 26), AreaId = 33, ProcesoId = 19, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 4, JornadaId = 3, EfectoId = 2, ClasificacionId = 11, ActividadId = 1, RiesgoId = 1, CausaBasicaId = 3, CausaInmediataId = 15, ParteCuerpoId = 15, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 14, Fecha = new DateTime(2020, 07, 03), AreaId = 45, ProcesoId = 23, Observado = "Alejandro Venegas", GeneroId = 2, TurnoId = 4, JornadaId = 2, EfectoId = 2, ClasificacionId = 6, ActividadId = 1, RiesgoId = 2, CausaBasicaId = 2, CausaInmediataId = 21, ParteCuerpoId = 13, Descripcion = "Descripción del incidente" },
                new Incidente { Id = 15, Fecha = new DateTime(2020, 07, 19), AreaId = 4, ProcesoId = 22, Observado = "Alejandro Venegas", GeneroId = 1, TurnoId = 2, JornadaId = 1, EfectoId = 1, ClasificacionId = 5, ActividadId = 2, RiesgoId = 3, CausaBasicaId = 1, CausaInmediataId = 20, ParteCuerpoId = 12, Descripcion = "Descripción del incidente" }
            );

            modelBuilder.Entity<CasiIncidente>().HasData(
                new CasiIncidente { Id = 1, GeneroId = 2, Fecha = new DateTime(2020, 2, 14), AreaId = 3, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 3, RiesgoId = 2, CasualidadId = 2, Descripcion = "Incumplimiento de la distancia de carga pesada" },
                new CasiIncidente { Id = 2, GeneroId = 1, Fecha = new DateTime(2020, 4, 21), AreaId = 5, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 2, RiesgoId = 2, CasualidadId = 6, Descripcion = "Posturas y manejo de cargas inadecuadas" },
                new CasiIncidente { Id = 3, GeneroId = 2, Fecha = new DateTime(2020, 5, 2), AreaId = 35, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 1, RiesgoId = 1, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 4, GeneroId = 1, Fecha = new DateTime(2020, 1, 2), AreaId = 7, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 2, RiesgoId = 3, CasualidadId = 7, Descripcion = "Temblor sin afectaci�n" },
                new CasiIncidente { Id = 5, GeneroId = 2, Fecha = new DateTime(2020, 7, 20), AreaId = 50, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 1, RiesgoId = 2, CasualidadId = 5, Descripcion = "Sin protecci�n" },
                new CasiIncidente { Id = 6, GeneroId = 2, Fecha = new DateTime(2020, 5, 13), AreaId = 34, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 5, JornadaId = 3, RiesgoId = 2, CasualidadId = 4, Descripcion = "Mala praxis" },
                new CasiIncidente { Id = 7, GeneroId = 2, Fecha = new DateTime(2020, 7, 11), AreaId = 6, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 2, RiesgoId = 1, CasualidadId = 2, Descripcion = "Expuesto a zonas inseguras" },
                new CasiIncidente { Id = 8, GeneroId = 1, Fecha = new DateTime(2020, 2, 5), AreaId = 19, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 1, RiesgoId = 2, CasualidadId = 5, Descripcion = "Sin protecci�n" },
                new CasiIncidente { Id = 9, GeneroId = 1, Fecha = new DateTime(2020, 1, 10), AreaId = 25, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 1, JornadaId = 2, RiesgoId = 2, CasualidadId = 7, Descripcion = "Temblor sin afectaci�n" },
                new CasiIncidente { Id = 10, GeneroId = 2, Fecha = new DateTime(2020, 4, 22), AreaId = 40, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 5, JornadaId = 3, RiesgoId = 2, CasualidadId = 5, Descripcion = "Sin protecci�n" },
                new CasiIncidente { Id = 11, GeneroId = 1, Fecha = new DateTime(2020, 7, 28), AreaId = 2, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 2, RiesgoId = 3, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 12, GeneroId = 2, Fecha = new DateTime(2020, 5, 8), AreaId = 1, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 3, RiesgoId = 1, CasualidadId = 1, Descripcion = "Acci�n sin preveer consecuencias" },
                new CasiIncidente { Id = 13, GeneroId = 2, Fecha = new DateTime(2020, 2, 5), AreaId = 15, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 2, RiesgoId = 2, CasualidadId = 6, Descripcion = "Posturas y manejo de cargas inadecuadas" },
                new CasiIncidente { Id = 14, GeneroId = 1, Fecha = new DateTime(2020, 3, 3), AreaId = 28, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 5, JornadaId = 2, RiesgoId = 2, CasualidadId = 4, Descripcion = "Mala praxis" },
                new CasiIncidente { Id = 15, GeneroId = 1, Fecha = new DateTime(2020, 6, 28), AreaId = 12, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 1, RiesgoId = 1, CasualidadId = 6, Descripcion = "Posturas y manejo de cargas inadecuadas" },
                new CasiIncidente { Id = 16, GeneroId = 2, Fecha = new DateTime(2020, 2, 23), AreaId = 4, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 2, RiesgoId = 1, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 17, GeneroId = 1, Fecha = new DateTime(2020, 6, 12), AreaId = 44, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 3, RiesgoId = 1, CasualidadId = 5, Descripcion = "Sin protecci�n" },
                new CasiIncidente { Id = 18, GeneroId = 1, Fecha = new DateTime(2020, 7, 1), AreaId = 39, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 5, JornadaId = 2, RiesgoId = 2, CasualidadId = 2, Descripcion = "Expuesto a zonas inseguras" },
                new CasiIncidente { Id = 19, GeneroId = 1, Fecha = new DateTime(2020, 7, 16), AreaId = 23, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 1, JornadaId = 3, RiesgoId = 1, CasualidadId = 2, Descripcion = "Expuesto a zonas inseguras" },
                new CasiIncidente { Id = 20, GeneroId = 1, Fecha = new DateTime(2020, 7, 13), AreaId = 46, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 1, RiesgoId = 2, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 21, GeneroId = 2, Fecha = new DateTime(2020, 3, 10), AreaId = 9, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 2, RiesgoId = 3, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 22, GeneroId = 2, Fecha = new DateTime(2020, 3, 4), AreaId = 10, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 2, RiesgoId = 1, CasualidadId = 5, Descripcion = "Sin protecci�n" },
                new CasiIncidente { Id = 23, GeneroId = 1, Fecha = new DateTime(2020, 2, 4), AreaId = 43, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 3, RiesgoId = 2, CasualidadId = 7, Descripcion = "Temblor sin afectaci�n" },
                new CasiIncidente { Id = 24, GeneroId = 1, Fecha = new DateTime(2020, 5, 12), AreaId = 50, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 3, JornadaId = 2, RiesgoId = 2, CasualidadId = 4, Descripcion = "Mala praxis" },
                new CasiIncidente { Id = 25, GeneroId = 1, Fecha = new DateTime(2020, 5, 14), AreaId = 34, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 1, JornadaId = 1, RiesgoId = 3, CasualidadId = 4, Descripcion = "Mala praxis" },
                new CasiIncidente { Id = 26, GeneroId = 2, Fecha = new DateTime(2020, 5, 13), AreaId = 21, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 3, RiesgoId = 1, CasualidadId = 6, Descripcion = "Posturas y manejo de cargas inadecuadas" },
                new CasiIncidente { Id = 27, GeneroId = 2, Fecha = new DateTime(2020, 6, 26), AreaId = 32, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 2, JornadaId = 2, RiesgoId = 2, CasualidadId = 1, Descripcion = "Acci�n sin preveer consecuencias" },
                new CasiIncidente { Id = 28, GeneroId = 1, Fecha = new DateTime(2020, 5, 16), AreaId = 16, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 1, JornadaId = 1, RiesgoId = 2, CasualidadId = 3, Descripcion = "No apto para la zona qu�mica" },
                new CasiIncidente { Id = 29, GeneroId = 2, Fecha = new DateTime(2020, 2, 7), AreaId = 24, ProcesoId = 2, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 3, RiesgoId = 1, CasualidadId = 4, Descripcion = "Mala praxis" },
                new CasiIncidente { Id = 30, GeneroId = 2, Fecha = new DateTime(2020, 1, 17), AreaId = 48, ProcesoId = 1, Observado = "Alejandro Venegas", TurnoId = 4, JornadaId = 2, RiesgoId = 2, CasualidadId = 5, Descripcion = "Sin protecci�n" }

            );

            modelBuilder.Entity<CondicionInsegura>().HasData(
                new CondicionInsegura { Id = 1, Fecha = new DateTime(2020, 04, 17), AreaId = 29, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 1 },
                new CondicionInsegura { Id = 2, Fecha = new DateTime(2020, 04, 21), AreaId = 17, ProcesoId = 11, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 3, Fecha = new DateTime(2020, 04, 27), AreaId = 6, ProcesoId = 21, FactorRiesgoId = 6, IndicadorRiesgoId = 1 },
                new CondicionInsegura { Id = 4, Fecha = new DateTime(2020, 04, 28), AreaId = 6, ProcesoId = 21, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 5, Fecha = new DateTime(2020, 04, 28), AreaId = 29, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 2 },
                new CondicionInsegura { Id = 6, Fecha = new DateTime(2020, 05, 05), AreaId = 29, ProcesoId = 14, FactorRiesgoId = 2, IndicadorRiesgoId = 6 },
                new CondicionInsegura { Id = 7, Fecha = new DateTime(2020, 05, 15), AreaId = 11, ProcesoId = 20, FactorRiesgoId = 6, IndicadorRiesgoId = 2 },
                new CondicionInsegura { Id = 8, Fecha = new DateTime(2020, 05, 18), AreaId = 6, ProcesoId = 21, FactorRiesgoId = 1, IndicadorRiesgoId = 5 },
                new CondicionInsegura { Id = 9, Fecha = new DateTime(2020, 05, 20), AreaId = 9, ProcesoId = 20, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 10, Fecha = new DateTime(2020, 06, 16), AreaId = 19, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 11, Fecha = new DateTime(2020, 06, 24), AreaId = 1, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 1 },
                new CondicionInsegura { Id = 12, Fecha = new DateTime(2020, 06, 26), AreaId = 5, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 13, Fecha = new DateTime(2020, 06, 26), AreaId = 5, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 14, Fecha = new DateTime(2020, 06, 26), AreaId = 5, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 2 },
                new CondicionInsegura { Id = 15, Fecha = new DateTime(2020, 06, 26), AreaId = 5, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 3 },
                new CondicionInsegura { Id = 16, Fecha = new DateTime(2020, 06, 26), AreaId = 5, ProcesoId = 14, FactorRiesgoId = 6, IndicadorRiesgoId = 3 }
            );


        }

    }
}