using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;
using Model.Enums;

namespace Data.EntityConfiguration
{
    internal class ReservaPeriodicaConfiguration : IEntityTypeConfiguration<ReservaPeriodica>
    {
        public void Configure(EntityTypeBuilder<ReservaPeriodica> builder)
        {
          
            builder.Property<int>("idReserva")
                .HasColumnName("idReserva")
                .IsRequired();

            builder.Property<int>("idCuatrimestre")
           .HasColumnName("idCuatrimestre")
           .IsRequired();

            builder.Property<DateTime>("fechaInicio")
                .HasColumnName("fechaInicio")
                .IsRequired();

            builder.Property<DateTime>("fechaFin")
                .HasColumnName("fechaFin")
                .IsRequired();

            builder.Property<TipoPeriodo>("periodo")
                .HasColumnName("periodo")
                .IsRequired();

            builder.HasMany<Cuatrimestre>("Cuatrimestres")
                .WithMany(c => c.ReservaPeriodica)
                .UsingEntity(j => j.ToTable("ReservaPeriodicaCuatrimestres"));
        }
    }
}