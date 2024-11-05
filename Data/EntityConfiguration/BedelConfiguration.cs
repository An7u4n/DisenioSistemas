using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class BedelConfiguration : IEntityTypeConfiguration<Bedel>
    {
        public void Configure(EntityTypeBuilder<Bedel> builder)
        {
            builder.Property<string>("usuario").HasColumnName("usuario").IsRequired();
            builder.Property<bool>("estado").HasColumnName("estado").IsRequired();
            builder.Property<int>("idBedel").HasColumnName("idBedel").IsRequired();
            builder.Property<string>("apellido").HasColumnName("apellido").IsRequired();
            builder.Property<string>("nombre").HasColumnName("nombre").IsRequired();
            builder.Property<Turno>("turno")
            .HasColumnName("turno")
            .HasConversion(
              v => v.ToString(),
              v => (Turno)Enum.Parse(typeof(Turno), v))
            .IsRequired();

            builder.HasOne<Usuario>()
               .WithOne()
               .HasForeignKey<Bedel>("idBedel");


        }
    }
}
