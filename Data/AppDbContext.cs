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
        public DbSet<Cuatrimestre> cuatrimestres { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Bedel> Bedeles { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<AulaInformatica> AulasInformatica { get; set; }
        public DbSet<AulaMultimedios> AulasMultimedios { get; set; }
        public DbSet<AulaSinRecursosAdicionales> AulasSinRecursosAdicionales { get; set; }
        
        public DbSet<Dia> dias { get; set; }
        public DbSet<DiaPeriodica> diasPeriodica { get; set; }
        public DbSet<DiaEsporadica> diasEsporadica { get; set; }

        public DbSet<Reserva> reserva { get; set; }
        public DbSet<ReservaEsporadica> reservaEsporadicas { get; set; }
        public DbSet<ReservaPeriodica> reservaPeriodicas { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnioLectivoConfiguration());
            modelBuilder.ApplyConfiguration(new CuatrimestreConfiguration());

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

            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.Entity<Reserva>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new ReservaEsporadicaConfiguration());
            modelBuilder.Entity<ReservaEsporadica>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new ReservaPeriodicaConfiguration());
            modelBuilder.Entity<ReservaPeriodica>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new DiaConfiguration());
            modelBuilder.Entity<Dia>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new DiaEsporadicaConfiguration());
            modelBuilder.Entity<DiaEsporadica>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new DiaPeriodicaConfiguration());
            modelBuilder.Entity<DiaPeriodica>().UseTptMappingStrategy();

            modelBuilder.Entity<DiaEsporadica>()
                .HasOne(d => d.ReservaEsporadica)
                .WithOne(r => r.DiaEsporadica)
                .HasForeignKey<DiaEsporadica>(d => d.idReserva);
            modelBuilder.Entity<DiaPeriodica>()
                .HasOne(d => d.ReservaPeriodica)
                .WithOne(r => r.DiaPeriodica)
                .HasForeignKey<DiaPeriodica>(d => d.idReserva);

            modelBuilder.Entity<Dia>()
                .HasOne(d => d.Aula)
                .WithOne(a => a.Dia)
                .HasForeignKey<Dia>(d => d.idAula);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Bedel)
                .WithMany(b => b.Reservas)
                .HasForeignKey(r => r.idBedel);

            base.OnModelCreating(modelBuilder);
        }
    }
}
