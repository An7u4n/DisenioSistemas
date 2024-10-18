using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AnioLectivo> AnioLectivos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Bedel> Bedeles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnioLectivo>(entity =>
            {
                entity.Property<string>("Anio").HasColumnName("Anio").IsRequired();
                entity.Property<int>("IdAnioLectivo").HasColumnName("IdAnioLectivo").IsRequired();
            });

            modelBuilder.Entity<Administrador>(entity => {
                entity.Property<string>("usuario").HasColumnName("usuario").IsRequired();
                entity.Property<bool>("estado").HasColumnName("estado").IsRequired();
                entity.Property<int>("idAdministrador").HasColumnName("idAdministrador").IsRequired();

                entity.HasKey("idAdministrador");
            });

            modelBuilder.Entity<Bedel>(entity => {
                entity.Property<string>("usuario").HasColumnName("usuario").IsRequired();
                entity.Property<bool>("estado").HasColumnName("estado").IsRequired();
                entity.Property<int>("idBedel").HasColumnName("idBedel").IsRequired();
                entity.Property<string>("apellido").HasColumnName("apellido").IsRequired();
                entity.Property<string>("nombre").HasColumnName("nombre").IsRequired();
                entity.Property<Turno>("turno")
                .HasColumnName("turno")
                .HasConversion(
                  v => v.ToString(),
                  v => (Turno)Enum.Parse(typeof(Turno), v))
                .IsRequired();

                entity.HasKey("idBedel");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
