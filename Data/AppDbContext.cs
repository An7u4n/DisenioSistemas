using Data.EntityConfiguration;
using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

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
            modelBuilder.ApplyConfiguration(new AnioLectivoConfiguration());

            modelBuilder.ApplyConfiguration(new AdministradorConfiguration());

            modelBuilder.ApplyConfiguration(new BedelConfiguration());

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());


            modelBuilder.Entity<Administrador>()
                        .ToTable("Administradores")
                        .HasBaseType<Usuario>();

            modelBuilder.Entity<Bedel>()
                        .ToTable("Bedeles")
                        .HasBaseType<Usuario>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
