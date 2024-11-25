using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Abstract;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class AulaSinRecursosAdicionalesConfiguration : IEntityTypeConfiguration<AulaSinRecursosAdicionales>
    {
        public void Configure(EntityTypeBuilder<AulaSinRecursosAdicionales> builder)
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

            builder.Property<bool>("poseeVentiladores")
                .HasColumnName("poseeVentiladores")
                .IsRequired();

            builder.HasBaseType<Aula>();
        }
    }
}
