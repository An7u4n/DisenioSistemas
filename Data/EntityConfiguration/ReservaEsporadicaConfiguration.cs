using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    internal class ReservaEsporadicaConfiguration : IEntityTypeConfiguration<ReservaEsporadica>
    {
        public void Configure(EntityTypeBuilder<ReservaEsporadica> builder)
        {
            builder.Property<int>("idReserva")
               .HasColumnName("idReserva")
               .IsRequired();

            builder.HasMany(r => r.DiasEsporadica)
                .WithOne()
                .HasForeignKey(d => d.idReserva)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}