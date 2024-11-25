using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    internal class DiaEsporadicaConfiguration : IEntityTypeConfiguration<DiaEsporadica>
    {
        public void Configure(EntityTypeBuilder<DiaEsporadica> builder)
        {
            builder.Property<int>("idResevaPeriodica")
           .HasColumnName("idResevaPeriodica")
           .IsRequired();

            builder.Property<DateTime>("dia")
                .HasColumnName("dia")
                .IsRequired();
            
        }
    }
}