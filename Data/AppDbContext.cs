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

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnioLectivoConfiguration());

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.Entity<Usuario>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AdministradorConfiguration());
            modelBuilder.Entity<Administrador>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new BedelConfiguration());
            modelBuilder.Entity<Bedel>().UseTptMappingStrategy();
           
            


            base.OnModelCreating(modelBuilder);
        }
    }
}
