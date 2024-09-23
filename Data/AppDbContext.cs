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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnioLectivo>(entity =>
            {
                entity.Property<string>("Anio").HasColumnName("Anio").IsRequired();
                entity.Property<int>("IdAnioLectivo").HasColumnName("IdAnioLectivo").IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
