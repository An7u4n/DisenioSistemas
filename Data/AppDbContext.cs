using DisenioSistemas.Model.Abstract;
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

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnioLectivo>(entity =>
            {
                entity.Property<string>("Anio").HasColumnName("Anio").IsRequired();
                entity.Property<int>("IdAnioLectivo").HasColumnName("IdAnioLectivo").IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.Property<string>("usuario").HasColumnName("usuario").IsRequired();
                entity.Property<bool>("estado").HasColumnName("estado").IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
