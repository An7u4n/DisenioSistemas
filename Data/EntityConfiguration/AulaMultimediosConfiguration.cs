using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class AulaMultimediosConfiguration : IEntityTypeConfiguration<AulaMultimedios>
    {
        public void Configure(EntityTypeBuilder<AulaMultimedios> builder)
        {
            builder.Property<int>("idAula")
                .HasColumnName("idAula")
                .IsRequired();

            builder.Property<int>("numero")
                .HasColumnName("numero")
                .IsRequired();

            builder.Property<int>("piso")
                .HasColumnName("piso")
                .IsRequired();

            builder.Property<bool>("aireAcondicionado")
                .HasColumnName("aireAcondicionado")
                .IsRequired();

            builder.Property<bool>("estado")
                .HasColumnName("estado")
                .IsRequired();

            builder.Property<int>("capacidad")
                .HasColumnName("capacidad")
                .IsRequired();

            builder.Property<bool>("televisor")
                .HasColumnName("televisor")
                .IsRequired();

            builder.Property<bool>("poseeVentiladores")
                .HasColumnName("poseeVentiladores")
                .IsRequired();

            builder.Property<bool>("canion")
                .HasColumnName("canion")
                .IsRequired();

            builder.Property<int>("cantidadComputadoras")
                .HasColumnName("cantidadComputadoras")
                .IsRequired();

            builder.HasBaseType<Aula>();
        }
    }
}
