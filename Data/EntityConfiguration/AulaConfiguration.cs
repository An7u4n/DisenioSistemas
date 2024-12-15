    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Abstract;
using Model.Enums;
using DisenioSistemas.Model.Enums;

namespace Data.EntityConfiguration
{
    public class AulaConfiguration : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {

            builder.Property<int>("idAula")
                .HasColumnName("idAula")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasKey("idAula");

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

            builder.Property<Pizarron>("tipoDePizarron")
                .HasColumnName("tipoDePizarron")
                .HasConversion(
                  v => v.ToString(),
                  v => (Pizarron)Enum.Parse(typeof(Turno), v))
                .IsRequired();
        }
    }
}
