using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Abstract;
using Model.Entity;
using Model.Enums;

namespace Data.EntityConfiguration
{
    internal class DiaPeriodicaConfiguration : IEntityTypeConfiguration<DiaPeriodica>
    {
        public void Configure(EntityTypeBuilder<DiaPeriodica> builder)
        {
            builder.Property<DiaSemana>("diaSemana")
            .HasColumnName("diaSemana")
            .IsRequired();
        }
    }
}