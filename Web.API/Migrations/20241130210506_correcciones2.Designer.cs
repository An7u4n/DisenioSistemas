﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241130210506_correcciones2")]
    partial class correcciones2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("DisenioSistemas.Model.Abstract.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("contrasena");

                    b.Property<bool>("estado")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estado");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("usuario");

                    b.HasKey("id");

                    b.ToTable("Usuarios");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Model.Abstract.Aula", b =>
                {
                    b.Property<int>("idAula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idAula");

                    b.Property<bool>("aireAcondicionado")
                        .HasColumnType("INTEGER")
                        .HasColumnName("aireAcondicionado");

                    b.Property<int>("capacidad")
                        .HasColumnType("INTEGER")
                        .HasColumnName("capacidad");

                    b.Property<bool>("estado")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estado");

                    b.Property<int>("numero")
                        .HasColumnType("INTEGER")
                        .HasColumnName("numero");

                    b.Property<int>("piso")
                        .HasColumnType("INTEGER")
                        .HasColumnName("piso");

                    b.Property<string>("tipoDePizarron")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tipoDePizarron");

                    b.HasKey("idAula");

                    b.ToTable("Aulas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Model.Abstract.Dia", b =>
                {
                    b.Property<int>("idDia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idDia");

                    b.Property<int>("diaSemana")
                        .HasColumnType("INTEGER")
                        .HasColumnName("diaSemana");

                    b.Property<int>("duracionMinutos")
                        .HasColumnType("INTEGER")
                        .HasColumnName("duracionMinutos");

                    b.Property<TimeOnly>("horaInicio")
                        .HasColumnType("TEXT")
                        .HasColumnName("horaInicio");

                    b.Property<int>("idAula")
                        .HasColumnType("INTEGER");

                    b.Property<int>("reservaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("idDia");

                    b.HasIndex("idAula");

                    b.HasIndex("reservaId")
                        .IsUnique();

                    b.ToTable("dias");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Model.Abstract.Reserva", b =>
                {
                    b.Property<int>("idReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idReservaPeriodica");

                    b.Property<string>("correoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("correoElectronico");

                    b.Property<string>("nombreCatedra")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("nombreCatedra");

                    b.Property<string>("profesor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("profesor");

                    b.HasKey("idReserva");

                    b.ToTable("reserva");

                    b.UseTptMappingStrategy();
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

            modelBuilder.Entity("Model.Entity.Cuatrimestre", b =>
                {
                    b.Property<int>("IdCuatrimestre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idCuatrimestre");

                    b.Property<DateOnly>("fechaFin")
                        .HasColumnType("TEXT")
                        .HasColumnName("fechaFin");

                    b.Property<DateOnly>("fechaInicio")
                        .HasColumnType("TEXT")
                        .HasColumnName("fechaInicio");

                    b.Property<int>("idAnio")
                        .HasColumnType("INTEGER")
                        .HasColumnName("idAnio");

                    b.Property<int>("numeroCuatrimestre")
                        .HasColumnType("INTEGER")
                        .HasColumnName("numeroCuatrimestre");

                    b.HasKey("IdCuatrimestre");

                    b.HasIndex("idAnio");

                    b.ToTable("Cuatrimestre", (string)null);
                });

            modelBuilder.Entity("Model.Entity.Administrador", b =>
                {
                    b.HasBaseType("DisenioSistemas.Model.Abstract.Usuario");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Model.Entity.Bedel", b =>
                {
                    b.HasBaseType("DisenioSistemas.Model.Abstract.Usuario");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("apellido");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<string>("turno")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("turno");

                    b.ToTable("Bedeles");
                });

            modelBuilder.Entity("Model.Entity.AulaInformatica", b =>
                {
                    b.HasBaseType("Model.Abstract.Aula");

                    b.Property<bool>("canion")
                        .HasColumnType("INTEGER")
                        .HasColumnName("canion");

                    b.Property<int>("cantidadComputadoras")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cantidadComputadoras");

                    b.ToTable("AulasInformatica");
                });

            modelBuilder.Entity("Model.Entity.AulaMultimedios", b =>
                {
                    b.HasBaseType("Model.Abstract.Aula");

                    b.Property<bool>("canion")
                        .HasColumnType("INTEGER")
                        .HasColumnName("canion");

                    b.Property<int>("cantidadComputadoras")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cantidadComputadoras");

                    b.Property<bool>("poseeVentiladores")
                        .HasColumnType("INTEGER")
                        .HasColumnName("poseeVentiladores");

                    b.Property<bool>("televisor")
                        .HasColumnType("INTEGER")
                        .HasColumnName("televisor");

                    b.ToTable("AulasMultimedios");
                });

            modelBuilder.Entity("Model.Entity.AulaSinRecursosAdicionales", b =>
                {
                    b.HasBaseType("Model.Abstract.Aula");

                    b.Property<bool>("poseeVentiladores")
                        .HasColumnType("INTEGER")
                        .HasColumnName("poseeVentiladores");

                    b.ToTable("AulasSinRecursosAdicionales");
                });

            modelBuilder.Entity("Model.Entity.DiaEsporadica", b =>
                {
                    b.HasBaseType("Model.Abstract.Dia");

                    b.Property<DateTime>("dia")
                        .HasColumnType("TEXT")
                        .HasColumnName("dia");

                    b.ToTable("diasEsporadica");
                });

            modelBuilder.Entity("Model.Entity.DiaPeriodica", b =>
                {
                    b.HasBaseType("Model.Abstract.Dia");

                    b.ToTable("diasPeriodica");
                });

            modelBuilder.Entity("Model.Entity.ReservaEsporadica", b =>
                {
                    b.HasBaseType("Model.Abstract.Reserva");

                    b.ToTable("reservaEsporadicas");
                });

            modelBuilder.Entity("Model.Entity.ReservaPeriodica", b =>
                {
                    b.HasBaseType("Model.Abstract.Reserva");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("TEXT")
                        .HasColumnName("fechaFin");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("TEXT")
                        .HasColumnName("fechaInicio");

                    b.Property<int>("idCuatrimestre")
                        .HasColumnType("INTEGER")
                        .HasColumnName("idCuatrimestre");

                    b.Property<int>("periodo")
                        .HasColumnType("INTEGER")
                        .HasColumnName("periodo");

                    b.HasIndex("idCuatrimestre");

                    b.ToTable("reservaPeriodicas");
                });

            modelBuilder.Entity("Model.Abstract.Dia", b =>
                {
                    b.HasOne("Model.Abstract.Aula", "aula")
                        .WithMany()
                        .HasForeignKey("idAula")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Abstract.Reserva", "Reserva")
                        .WithOne("Dia")
                        .HasForeignKey("Model.Abstract.Dia", "reservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");

                    b.Navigation("aula");
                });

            modelBuilder.Entity("Model.Entity.Cuatrimestre", b =>
                {
                    b.HasOne("Model.Entity.AnioLectivo", null)
                        .WithMany()
                        .HasForeignKey("idAnio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.Administrador", b =>
                {
                    b.HasOne("DisenioSistemas.Model.Abstract.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.Administrador", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.Bedel", b =>
                {
                    b.HasOne("DisenioSistemas.Model.Abstract.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.Bedel", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.AulaInformatica", b =>
                {
                    b.HasOne("Model.Abstract.Aula", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.AulaInformatica", "idAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.AulaMultimedios", b =>
                {
                    b.HasOne("Model.Abstract.Aula", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.AulaMultimedios", "idAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.AulaSinRecursosAdicionales", b =>
                {
                    b.HasOne("Model.Abstract.Aula", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.AulaSinRecursosAdicionales", "idAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.DiaEsporadica", b =>
                {
                    b.HasOne("Model.Abstract.Dia", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.DiaEsporadica", "idDia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.DiaPeriodica", b =>
                {
                    b.HasOne("Model.Abstract.Dia", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.DiaPeriodica", "idDia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.ReservaEsporadica", b =>
                {
                    b.HasOne("Model.Abstract.Reserva", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.ReservaEsporadica", "idReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.ReservaPeriodica", b =>
                {
                    b.HasOne("Model.Entity.Cuatrimestre", "cuatrimestre")
                        .WithMany()
                        .HasForeignKey("idCuatrimestre")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Abstract.Reserva", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.ReservaPeriodica", "idReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cuatrimestre");
                });

            modelBuilder.Entity("Model.Abstract.Reserva", b =>
                {
                    b.Navigation("Dia")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
