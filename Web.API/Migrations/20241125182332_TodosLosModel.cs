using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class TodosLosModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuatrimestres",
                columns: table => new
                {
                    idCuatrimestre = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numeroCuatrimestre = table.Column<int>(type: "INTEGER", nullable: false),
                    fechaInicio = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    fechaFin = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    idAnio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuatrimestres", x => x.idCuatrimestre);
                    table.ForeignKey(
                        name: "FK_Cuatrimestres_AnioLectivos_idAnio",
                        column: x => x.idAnio,
                        principalTable: "AnioLectivos",
                        principalColumn: "IdAnioLectivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dias",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    duracionMinutos = table.Column<int>(type: "INTEGER", nullable: false),
                    horaInicio = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    diaSemana = table.Column<int>(type: "INTEGER", nullable: false),
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dias", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_dias_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reserva",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profesor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    nombreCatedra = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    correoElectronico = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.idReserva);
                });

            migrationBuilder.CreateTable(
                name: "reservaEsporadicas",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaEsporadicas", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_reservaEsporadicas_reserva_idReserva",
                        column: x => x.idReserva,
                        principalTable: "reserva",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservaPeriodicas",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCuatrimestre = table.Column<int>(type: "INTEGER", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    periodo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaPeriodicas", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_reservaPeriodicas_Cuatrimestres_idCuatrimestre",
                        column: x => x.idCuatrimestre,
                        principalTable: "Cuatrimestres",
                        principalColumn: "idCuatrimestre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservaPeriodicas_reserva_idReserva",
                        column: x => x.idReserva,
                        principalTable: "reserva",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diasEsporadica",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    reservaEsporadicaidReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    idResevaPeriodica = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diasEsporadica", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_diasEsporadica_dias_idDia",
                        column: x => x.idDia,
                        principalTable: "dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diasEsporadica_reservaEsporadicas_reservaEsporadicaidReserva",
                        column: x => x.reservaEsporadicaidReserva,
                        principalTable: "reservaEsporadicas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diasPeriodica",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reservaPeriodicaidReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    idResevaPeriodica = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diasPeriodica", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_diasPeriodica_dias_idDia",
                        column: x => x.idDia,
                        principalTable: "dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diasPeriodica_reservaPeriodicas_reservaPeriodicaidReserva",
                        column: x => x.reservaPeriodicaidReserva,
                        principalTable: "reservaPeriodicas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuatrimestres_idAnio",
                table: "Cuatrimestres",
                column: "idAnio");

            migrationBuilder.CreateIndex(
                name: "IX_dias_idAula",
                table: "dias",
                column: "idAula");

            migrationBuilder.CreateIndex(
                name: "IX_diasEsporadica_reservaEsporadicaidReserva",
                table: "diasEsporadica",
                column: "reservaEsporadicaidReserva");

            migrationBuilder.CreateIndex(
                name: "IX_diasPeriodica_reservaPeriodicaidReserva",
                table: "diasPeriodica",
                column: "reservaPeriodicaidReserva");

            migrationBuilder.CreateIndex(
                name: "IX_reservaPeriodicas_idCuatrimestre",
                table: "reservaPeriodicas",
                column: "idCuatrimestre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diasEsporadica");

            migrationBuilder.DropTable(
                name: "diasPeriodica");

            migrationBuilder.DropTable(
                name: "reservaEsporadicas");

            migrationBuilder.DropTable(
                name: "dias");

            migrationBuilder.DropTable(
                name: "reservaPeriodicas");

            migrationBuilder.DropTable(
                name: "Cuatrimestres");

            migrationBuilder.DropTable(
                name: "reserva");
        }
    }
}
