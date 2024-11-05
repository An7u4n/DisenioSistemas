using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class AdministradorConfiguration : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.Property<string>("usuario").HasColumnName("usuario").IsRequired();
            builder.Property<bool>("estado").HasColumnName("estado").IsRequired();

            

            builder.HasOne<Usuario>()
               .WithOne()
               .HasForeignKey<Administrador>("idAdministrador");
        }
    }
}
