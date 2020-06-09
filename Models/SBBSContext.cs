using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SBBS.Models
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

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Bbs> Bbs { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<CasiIncidente> CasiIncidente { get; set; }
        public virtual DbSet<Casualidad> Casualidad { get; set; }
        public virtual DbSet<CausaBasica> CausaBasica { get; set; }
        public virtual DbSet<CausaInmediata> CausaInmediata { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Comportamiento> Comportamiento { get; set; }
        public virtual DbSet<CondicionesInseguras> CondicionesInseguras { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Efecto> Efecto { get; set; }
        public virtual DbSet<FactorRiesgo> FactorRiesgo { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Incidente> Incidente { get; set; }
        public virtual DbSet<IndicadorRiesgo> IndicadorRiesgo { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<Observado> Observado { get; set; }
        public virtual DbSet<ParteCuerpo> ParteCuerpo { get; set; }
        public virtual DbSet<Proceso> Proceso { get; set; }
        public virtual DbSet<Riesgo> Riesgo { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoComportamiento> TipoComportamiento { get; set; }
        public virtual DbSet<TipoObservado> TipoObservado { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.Property(e => e.ActividadId)
                    .HasColumnName("actividad_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Actividad1)
                    .IsRequired()
                    .HasColumnName("actividad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId)
                    .HasColumnName("area_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area1)
                    .IsRequired()
                    .HasColumnName("area")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bbs>(entity =>
            {
                entity.ToTable("BBS");

                entity.Property(e => e.BbsId)
                    .HasColumnName("bbs_id")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.ComportamientoId).HasColumnName("comportamiento_id");

                entity.Property(e => e.FechaBbs)
                    .IsRequired()
                    .HasColumnName("fecha_bbs")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProcesoId).HasColumnName("proceso_id");

                entity.Property(e => e.TipoComportamientoId).HasColumnName("tipo_comportamiento_id");

                entity.Property(e => e.TipoObservadoId).HasColumnName("tipo_observado_id");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Area");

                entity.HasOne(d => d.ColaboradorNavigation)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Departamento");

                entity.HasOne(d => d.Colaborador1)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Proceso");

                entity.HasOne(d => d.Comportamiento)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.ComportamientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Comportamiento");

                entity.HasOne(d => d.ComportamientoNavigation)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.ComportamientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Tipo_Observado");

                entity.HasOne(d => d.TipoComportamiento)
                    .WithMany(p => p.Bbs)
                    .HasForeignKey(d => d.TipoComportamientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BBS_Tipo_Comportamiento");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionBitacora)
                    .IsRequired()
                    .HasColumnName("descripcion_bitacora")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaBitacora)
                    .HasColumnName("fecha_bitacora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bitacora_Usuario");
            });

            modelBuilder.Entity<CasiIncidente>(entity =>
            {
                entity.ToTable("Casi_Incidente");

                entity.Property(e => e.CasiIncidenteId)
                    .HasColumnName("casi_incidente_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CasualidadId).HasColumnName("casualidad_id");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.DescripcionCasiIncidente)
                    .IsRequired()
                    .HasColumnName("descripcion_casi_incidente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JornadaId).HasColumnName("jornada_id");

                entity.Property(e => e.ObservadoId).HasColumnName("observado_id");

                entity.Property(e => e.ProcesoId).HasColumnName("proceso_id");

                entity.Property(e => e.RiesgoId).HasColumnName("riesgo_id");

                entity.Property(e => e.TurnoId).HasColumnName("turno_id");

                entity.HasOne(d => d.Casualidad)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.CasualidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Casualidad");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Departamento");

                entity.HasOne(d => d.Proceso)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Area");

                entity.HasOne(d => d.ProcesoNavigation)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Observado");

                entity.HasOne(d => d.Proceso1)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Proceso");

                entity.HasOne(d => d.Riesgo)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.RiesgoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Riesgo");

                entity.HasOne(d => d.Turno)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.TurnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Jornada");

                entity.HasOne(d => d.TurnoNavigation)
                    .WithMany(p => p.CasiIncidente)
                    .HasForeignKey(d => d.TurnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Casi_Incidente_Turno");
            });

            modelBuilder.Entity<Casualidad>(entity =>
            {
                entity.Property(e => e.CasualidadId)
                    .HasColumnName("casualidad_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Casualidad1)
                    .IsRequired()
                    .HasColumnName("casualidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CausaBasica>(entity =>
            {
                entity.ToTable("Causa_Basica");

                entity.Property(e => e.CausaBasicaId)
                    .HasColumnName("causa_basica_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CausaBasica1)
                    .IsRequired()
                    .HasColumnName("causa_basica")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CausaInmediata>(entity =>
            {
                entity.ToTable("Causa_Inmediata");

                entity.Property(e => e.CausaInmediataId)
                    .HasColumnName("causa_inmediata_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CausaInmediata1)
                    .IsRequired()
                    .HasColumnName("causa_inmediata")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("clasificacion_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Clasificacion1)
                    .IsRequired()
                    .HasColumnName("clasificacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.Property(e => e.ColaboradorId)
                    .HasColumnName("colaborador_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidoColaborador)
                    .IsRequired()
                    .HasColumnName("apellido_colaborador")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.Property(e => e.NombreColaborador)
                    .IsRequired()
                    .HasColumnName("nombre_colaborador")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PuestoColaborador)
                    .IsRequired()
                    .HasColumnName("puesto_colaborador")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Colaborador)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colaborador_Departamento");
            });

            modelBuilder.Entity<Comportamiento>(entity =>
            {
                entity.Property(e => e.ComportamientoId)
                    .HasColumnName("comportamiento_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comportamiento1)
                    .IsRequired()
                    .HasColumnName("comportamiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionComportamiento)
                    .IsRequired()
                    .HasColumnName("descripcion_comportamiento")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CondicionesInseguras>(entity =>
            {
                entity.HasKey(e => e.CondicionesId)
                    .HasName("PK_Condiciones_Inseguras_1");

                entity.ToTable("Condiciones_Inseguras");

                entity.Property(e => e.CondicionesId)
                    .HasColumnName("condiciones_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.FactorRiesgoId).HasColumnName("factor_riesgo_id");

                entity.Property(e => e.FechaCondicion)
                    .HasColumnName("fecha_condicion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IndicadorRiesgoId).HasColumnName("indicador_riesgo_id");

                entity.Property(e => e.ProcesoId).HasColumnName("proceso_id");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.CondicionesInseguras)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condiciones_Inseguras_Area");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.CondicionesInseguras)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condiciones_Inseguras_Departamento");

                entity.HasOne(d => d.FactorRiesgo)
                    .WithMany(p => p.CondicionesInseguras)
                    .HasForeignKey(d => d.FactorRiesgoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condiciones_Inseguras_Factor_Riesgo");

                entity.HasOne(d => d.IndicadorRiesgo)
                    .WithMany(p => p.CondicionesInseguras)
                    .HasForeignKey(d => d.IndicadorRiesgoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condiciones_Inseguras_Indicador_Riesgo");

                entity.HasOne(d => d.Proceso)
                    .WithMany(p => p.CondicionesInseguras)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condiciones_Inseguras_Proceso");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId)
                    .HasColumnName("departamento_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasColumnName("nombre_departamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ColaboradorNavigation)
                    .WithMany(p => p.DepartamentoNavigation)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_Colaborador");
            });

            modelBuilder.Entity<Efecto>(entity =>
            {
                entity.Property(e => e.EfectoId)
                    .HasColumnName("efecto_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Efecto1)
                    .IsRequired()
                    .HasColumnName("efecto")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FactorRiesgo>(entity =>
            {
                entity.ToTable("Factor_Riesgo");

                entity.Property(e => e.FactorRiesgoId)
                    .HasColumnName("factor_riesgo_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FactorRiesgo1)
                    .IsRequired()
                    .HasColumnName("factor_riesgo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.GeneroId)
                    .HasColumnName("genero_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Genero1)
                    .IsRequired()
                    .HasColumnName("genero")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.Property(e => e.IncidenteId)
                    .HasColumnName("incidente_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActividadId).HasColumnName("actividad_id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CausaBasicaId).HasColumnName("causa_basica_id");

                entity.Property(e => e.CausaInmediataId).HasColumnName("causa_inmediata_id");

                entity.Property(e => e.ClasificacionId).HasColumnName("clasificacion_id");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.DescripcionIncidente)
                    .IsRequired()
                    .HasColumnName("descripcion_incidente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfectoId).HasColumnName("efecto_id");

                entity.Property(e => e.FechaIncidente)
                    .HasColumnName("fecha_incidente")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GeneroId).HasColumnName("genero_id");

                entity.Property(e => e.JornadaId).HasColumnName("jornada_id");

                entity.Property(e => e.ObservadoId).HasColumnName("observado_id");

                entity.Property(e => e.ParteId).HasColumnName("parte_id");

                entity.Property(e => e.ProcesoId).HasColumnName("proceso_id");

                entity.Property(e => e.RiesgoId).HasColumnName("riesgo_id");

                entity.Property(e => e.TurnoId).HasColumnName("turno_id");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ActividadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Actividad");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Area");

                entity.HasOne(d => d.CausaBasica)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.CausaBasicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Causa_Basica");

                entity.HasOne(d => d.CausaInmediata)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.CausaInmediataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Causa_Inmediata");

                entity.HasOne(d => d.CausaInmediataNavigation)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.CausaInmediataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Parte_Cuerpo");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Clasificacion");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Departamento");

                entity.HasOne(d => d.ColaboradorNavigation)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Riesgo");

                entity.HasOne(d => d.Efecto)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.EfectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Jornada");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.GeneroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Genero");

                entity.HasOne(d => d.Observado)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ObservadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Proceso");

                entity.HasOne(d => d.ObservadoNavigation)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ObservadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Turno");

                entity.HasOne(d => d.Proceso)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Efecto");

                entity.HasOne(d => d.ProcesoNavigation)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidente_Observado");
            });

            modelBuilder.Entity<IndicadorRiesgo>(entity =>
            {
                entity.ToTable("Indicador_Riesgo");

                entity.Property(e => e.IndicadorRiesgoId)
                    .HasColumnName("indicador_riesgo_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IndicadorRiesgo1)
                    .IsRequired()
                    .HasColumnName("indicador_riesgo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.Property(e => e.JornadaId)
                    .HasColumnName("jornada_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Jornada1)
                    .IsRequired()
                    .HasColumnName("jornada")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Observado>(entity =>
            {
                entity.Property(e => e.ObservadoId)
                    .HasColumnName("observado_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreObservado)
                    .IsRequired()
                    .HasColumnName("nombre_observado")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParteCuerpo>(entity =>
            {
                entity.HasKey(e => e.ParteId)
                    .HasName("PK_ParteCuerpo");

                entity.ToTable("Parte_Cuerpo");

                entity.Property(e => e.ParteId)
                    .HasColumnName("parte_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Parte)
                    .IsRequired()
                    .HasColumnName("parte")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.Property(e => e.ProcesoId)
                    .HasColumnName("proceso_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Proceso1)
                    .IsRequired()
                    .HasColumnName("proceso")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Riesgo>(entity =>
            {
                entity.HasKey(e => e.RiegoId);

                entity.Property(e => e.RiegoId)
                    .HasColumnName("riego_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Riesgo1)
                    .IsRequired()
                    .HasColumnName("riesgo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.RolId)
                    .HasColumnName("rol_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasColumnName("descripcion_rol")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("nombre_rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoComportamiento>(entity =>
            {
                entity.ToTable("Tipo_Comportamiento");

                entity.Property(e => e.TipoComportamientoId)
                    .HasColumnName("tipo_comportamiento_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TipoComportamiento1)
                    .IsRequired()
                    .HasColumnName("tipo_comportamiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoObservado>(entity =>
            {
                entity.ToTable("Tipo_Observado");

                entity.Property(e => e.TipoObservadoId)
                    .HasColumnName("tipo_observado_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TipoObservado1)
                    .IsRequired()
                    .HasColumnName("tipo_observado")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.Property(e => e.TurnoId)
                    .HasColumnName("turno_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Turno1)
                    .IsRequired()
                    .HasColumnName("turno")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Colaborador");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
