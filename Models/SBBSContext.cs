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
        public DbSet<Rol> Roles {get;set;}
        public DbSet<Vista> Vistas{get;set;}
        public DbSet<RolVista> RolVistas{get;set;}
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
                new Vista{Id = 1,NombreVista = "Reportes"},
                new Vista{Id = 2,NombreVista = "Graficos"},
                new Vista{Id = 3,NombreVista = "Administrar"},
                new Vista{Id = 4,NombreVista = "Mantenimiento"}
            );
        }

    }
}