using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Abstract;
using Model.Enums;

namespace Data.EntityConfiguration
{
    internal class DiaConfiguration : IEntityTypeConfiguration<Dia>
    {
        public void Configure(EntityTypeBuilder<Dia> builder)
        {
           
            builder.Property<int>("idDia")
                .HasColumnName("idDia")
                .ValueGeneratedOnAdd();

            builder.HasKey("idDia");

            builder.Property<int>("duracionMinutos")
                .HasColumnName("duracionMinutos")
                .IsRequired();

            builder.Property<TimeOnly>("horaInicio")
                .HasColumnName("horaInicio")
                .IsRequired();

            builder.Property<DiaSemana>("diaSemana")
                .HasColumnName("diaSemana")
                .IsRequired();
        }
    }
}