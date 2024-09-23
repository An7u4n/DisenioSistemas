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
    [Migration("20240923171719_InicializacionBdd")]
    partial class InicializacionBdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

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
#pragma warning restore 612, 618
        }
    }
}
