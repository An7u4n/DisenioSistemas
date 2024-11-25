using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Abstract;

namespace Data.EntityConfiguration
{
    internal class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.Property<int>("idReserva")
            .HasColumnName("idReserva")
            .ValueGeneratedOnAdd();


            builder.HasKey("idReserva");

            builder.Property<string>("profesor")
                .HasColumnName("profesor")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property<string>("nombreCatedra")
                .HasColumnName("nombreCatedra")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property<string>("correoElectronico")
                .HasColumnName("correoElectronico")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}