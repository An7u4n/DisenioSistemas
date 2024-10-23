using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class AnioLectivoConfiguration : IEntityTypeConfiguration<AnioLectivo>
    {
        public void Configure(EntityTypeBuilder<AnioLectivo> builder)
        {
            builder.Property<string>("Anio").HasColumnName("Anio").IsRequired();
            builder.Property<int>("IdAnioLectivo").HasColumnName("IdAnioLectivo").IsRequired();

            builder.HasKey("IdAnioLectivo");
        }
    }
}
