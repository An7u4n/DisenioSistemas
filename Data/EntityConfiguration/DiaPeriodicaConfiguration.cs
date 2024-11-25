using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    internal class DiaPeriodicaConfiguration : IEntityTypeConfiguration<DiaPeriodica>
    {
        public void Configure(EntityTypeBuilder<DiaPeriodica> builder)
        {
            builder.Property<int>("idResevaPeriodica")
             .HasColumnName("idResevaPeriodica")
             .IsRequired();
        }
    }
}