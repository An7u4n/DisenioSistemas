using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class InicializacionBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnioLectivos",
                columns: table => new
                {
                    IdAnioLectivo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Anio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnioLectivos", x => x.IdAnioLectivo);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numero = table.Column<int>(type: "INTEGER", nullable: false),
                    piso = table.Column<int>(type: "INTEGER", nullable: false),
                    aireAcondicionado = table.Column<bool>(type: "INTEGER", nullable: false),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    tipoDePizarron = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.idAula);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contrasena = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    usuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cuatrimestre",
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
                    table.PrimaryKey("PK_Cuatrimestre", x => x.idCuatrimestre);
                    table.ForeignKey(
                        name: "FK_Cuatrimestre_AnioLectivos_idAnio",
                        column: x => x.idAnio,
                        principalTable: "AnioLectivos",
                        principalColumn: "IdAnioLectivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AulasInformatica",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    canion = table.Column<bool>(type: "INTEGER", nullable: false),
                    cantidadComputadoras = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasInformatica", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasInformatica_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AulasMultimedios",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    canion = table.Column<bool>(type: "INTEGER", nullable: false),
                    cantidadComputadoras = table.Column<int>(type: "INTEGER", nullable: false),
                    poseeVentiladores = table.Column<bool>(type: "INTEGER", nullable: false),
                    televisor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasMultimedios", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasMultimedios_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AulasSinRecursosAdicionales",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    poseeVentiladores = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasSinRecursosAdicionales", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasSinRecursosAdicionales_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dias",
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
                    table.PrimaryKey("PK_Dias", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_Dias_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_id",
                        column: x => x.id,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bedeles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    turno = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedeles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bedeles_Usuarios_id",
                        column: x => x.id,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profesor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    nombreCatedra = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    correoElectronico = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DiaidDia = table.Column<int>(type: "INTEGER", nullable: false),
                    idBedel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Bedeles_idBedel",
                        column: x => x.idBedel,
                        principalTable: "Bedeles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Dias_DiaidDia",
                        column: x => x.DiaidDia,
                        principalTable: "Dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasEsporadica",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasEsporadica", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_ReservasEsporadica_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasPeriodica",
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
                    table.PrimaryKey("PK_ReservasPeriodica", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_ReservasPeriodica_Cuatrimestre_idCuatrimestre",
                        column: x => x.idCuatrimestre,
                        principalTable: "Cuatrimestre",
                        principalColumn: "idCuatrimestre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservasPeriodica_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasEsporadica",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasEsporadica", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_DiasEsporadica_Dias_idDia",
                        column: x => x.idDia,
                        principalTable: "Dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasEsporadica_ReservasEsporadica_idReserva",
                        column: x => x.idReserva,
                        principalTable: "ReservasEsporadica",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasPeriodica",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasPeriodica", x => x.idDia);
                    table.ForeignKey(
                        name: "FK_DiasPeriodica_Dias_idDia",
                        column: x => x.idDia,
                        principalTable: "Dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasPeriodica_ReservasPeriodica_idReserva",
                        column: x => x.idReserva,
                        principalTable: "ReservasPeriodica",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuatrimestre_idAnio",
                table: "Cuatrimestre",
                column: "idAnio");

            migrationBuilder.CreateIndex(
                name: "IX_Dias_idAula",
                table: "Dias",
                column: "idAula");

            migrationBuilder.CreateIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica",
                column: "idReserva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiasPeriodica_idReserva",
                table: "DiasPeriodica",
                column: "idReserva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_DiaidDia",
                table: "Reservas",
                column: "DiaidDia");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_idBedel",
                table: "Reservas",
                column: "idBedel");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPeriodica_idCuatrimestre",
                table: "ReservasPeriodica",
                column: "idCuatrimestre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "AulasInformatica");

            migrationBuilder.DropTable(
                name: "AulasMultimedios");

            migrationBuilder.DropTable(
                name: "AulasSinRecursosAdicionales");

            migrationBuilder.DropTable(
                name: "DiasEsporadica");

            migrationBuilder.DropTable(
                name: "DiasPeriodica");

            migrationBuilder.DropTable(
                name: "ReservasEsporadica");

            migrationBuilder.DropTable(
                name: "ReservasPeriodica");

            migrationBuilder.DropTable(
                name: "Cuatrimestre");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "AnioLectivos");

            migrationBuilder.DropTable(
                name: "Bedeles");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Aulas");
        }
    }
}
