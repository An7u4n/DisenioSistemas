﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241004160859_usersadded")]
    partial class usersadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Model.Entity.Administrador", b =>
                {
                    b.Property<int>("idAdministrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idAdministrador");

                    b.Property<bool>("estado")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estado");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("usuario");

                    b.HasKey("idAdministrador");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Model.Entity.AnioLectivo", b =>
                {
                    b.Property<int>("IdAnioLectivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("IdAnioLectivo");

                    b.Property<string>("Anio")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Anio");

                    b.HasKey("IdAnioLectivo");

                    b.ToTable("AnioLectivos");
                });

            modelBuilder.Entity("Model.Entity.Bedel", b =>
                {
                    b.Property<int>("idBedel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idBedel");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("apellido");

                    b.Property<bool>("estado")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estado");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<int>("turno")
                        .HasColumnType("INTEGER")
                        .HasColumnName("turno");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("usuario");

                    b.HasKey("idBedel");

                    b.ToTable("Bedeles");
                });
#pragma warning restore 612, 618
        }
    }
}
