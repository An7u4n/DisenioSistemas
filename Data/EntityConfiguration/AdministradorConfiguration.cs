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
            builder.Property<int>("id").HasColumnName("id").IsRequired();
            builder.Property<string>("usuario").HasColumnName("usuario").IsRequired();
            builder.Property<bool>("estado").HasColumnName("estado").IsRequired();



            builder.HasBaseType<Usuario>();
        }
    }
}
