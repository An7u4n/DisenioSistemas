using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class modifiacionesCuatrimestreReservaPeriodica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservasPeriodica_Cuatrimestre_idCuatrimestre",
                table: "ReservasPeriodica");

            migrationBuilder.DropIndex(
                name: "IX_ReservasPeriodica_idCuatrimestre",
                table: "ReservasPeriodica");

            migrationBuilder.DropIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica");

            migrationBuilder.AddColumn<int>(
                name: "AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservaPeriodicaCuatrimestres",
                columns: table => new
                {
                    CuatrimestresIdCuatrimestre = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservaPeriodicaidReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaPeriodicaCuatrimestres", x => new { x.CuatrimestresIdCuatrimestre, x.ReservaPeriodicaidReserva });
                    table.ForeignKey(
                        name: "FK_ReservaPeriodicaCuatrimestres_Cuatrimestre_CuatrimestresIdCuatrimestre",
                        column: x => x.CuatrimestresIdCuatrimestre,
                        principalTable: "Cuatrimestre",
                        principalColumn: "idCuatrimestre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaPeriodicaCuatrimestres_ReservasPeriodica_ReservaPeriodicaidReserva",
                        column: x => x.ReservaPeriodicaidReserva,
                        principalTable: "ReservasPeriodica",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica",
                column: "idReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Cuatrimestre_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                column: "AnioLectivoIdAnioLectivo");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPeriodicaCuatrimestres_ReservaPeriodicaidReserva",
                table: "ReservaPeriodicaCuatrimestres",
                column: "ReservaPeriodicaidReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                column: "AnioLectivoIdAnioLectivo",
                principalTable: "AnioLectivos",
                principalColumn: "IdAnioLectivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre");

            migrationBuilder.DropTable(
                name: "ReservaPeriodicaCuatrimestres");

            migrationBuilder.DropIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica");

            migrationBuilder.DropIndex(
                name: "IX_Cuatrimestre_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre");

            migrationBuilder.DropColumn(
                name: "AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPeriodica_idCuatrimestre",
                table: "ReservasPeriodica",
                column: "idCuatrimestre");

            migrationBuilder.CreateIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica",
                column: "idReserva",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasPeriodica_Cuatrimestre_idCuatrimestre",
                table: "ReservasPeriodica",
                column: "idCuatrimestre",
                principalTable: "Cuatrimestre",
                principalColumn: "idCuatrimestre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
