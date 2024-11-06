using Data.EntityConfiguration;
using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
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
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<AulaInformatica> AulasInformatica { get; set; }
        public DbSet<AulaMultimedios> AulasMultimedios { get; set; }
        public DbSet<AulaSinRecursosAdicionales> AulasSinRecursosAdicionales { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnioLectivoConfiguration());

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.Entity<Usuario>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AdministradorConfiguration());
            modelBuilder.Entity<Administrador>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new BedelConfiguration());
            modelBuilder.Entity<Bedel>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AulaConfiguration());
            modelBuilder.Entity<Aula>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AulaMultimediosConfiguration());
            modelBuilder.Entity<AulaMultimedios>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AulaSinRecursosAdicionalesConfiguration());
            modelBuilder.Entity<AulaSinRecursosAdicionales>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new AulaInformaticaConfiguration());
            modelBuilder.Entity<AulaInformatica>().UseTptMappingStrategy();




            base.OnModelCreating(modelBuilder);
        }
    }
}
