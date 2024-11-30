using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entity;

namespace Data.EntityConfiguration
{
    internal class CuatrimestreConfiguration : IEntityTypeConfiguration<Cuatrimestre>
    {
        public void Configure(EntityTypeBuilder<Cuatrimestre> builder)
        {
            builder.ToTable("Cuatrimestre");

            
            builder.Property<int>("IdCuatrimestre")
                .HasColumnName("idCuatrimestre")
                .ValueGeneratedOnAdd();

         
            builder.Property<int>("numeroCuatrimestre")
                .HasColumnName("numeroCuatrimestre")
                .IsRequired();

            builder.Property<DateOnly>("fechaInicio")
                .HasColumnName("fechaInicio")
                .IsRequired();

            builder.Property<DateOnly>("fechaFin")
                .HasColumnName("fechaFin")
                .IsRequired();

        
            builder.Property<int>("idAnio")
                .HasColumnName("idAnio")
                .IsRequired();

            builder.HasOne<AnioLectivo>()
            .WithMany() 
            .HasForeignKey("idAnio")
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}