using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            
            builder.ToTable("Usuarios");


            builder.HasKey("id");

            
            builder.Property<string>("usuario")
                .HasColumnName("usuario")
                .IsRequired();

            builder.Property<string>("contrasena")
                .HasColumnName("contrasena")
                .IsRequired();

            builder.Property<bool>("estado")
                .HasColumnName("estado")
                .IsRequired();

           
        }
    }
}