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
        

        public DbSet<Value> Values {get;set;}
        public DbSet<Rol> Roles{get;set;}
        public DbSet<Vista> Vistas{get;set;}
        public DbSet<RolVista> RolVistas{get;set;}
        public DbSet<Riesgo> Riesgos{get;set;}
        public DbSet<Turno> Turnos{get;set;}
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
        public virtual DbSet<Clasificacion> Clasificaciones{get;set;}

        public virtual DbSet<Actividad> Actividades {get;set;}
        public virtual DbSet<Casualidad> Casualidades{get;set;}
        public virtual DbSet<Comportamiento> Comportamientos{get;set;}
        public virtual DbSet<Departamento> Departmentos{get;set;}
        public virtual DbSet<Colaborador> Colaboradores{get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {      

             // Relations
             modelBuilder.Entity<RolVista>()
             .HasKey(rv => new{rv.RolId, rv.VistaId});
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
                new Vista{Id = 1,Nombre = "Reportes"},
                new Vista{Id = 2,Nombre = "Graficos"},
                new Vista{Id = 3,Nombre = "Administrar"},
                new Vista{Id = 4,Nombre = "Mantenimiento"}
            );

            modelBuilder.Entity<Rol>().HasData(
                new Rol {Id = 1, Nombre = "Administrador"}
            );
        }

    }
}