using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dias_Aulas_idAula",
                table: "dias");

            migrationBuilder.DropForeignKey(
                name: "FK_dias_reserva_reservaId",
                table: "dias");

            migrationBuilder.DropIndex(
                name: "IX_dias_idAula",
                table: "dias");

            migrationBuilder.RenameColumn(
                name: "reservaId",
                table: "dias",
                newName: "idReserva");

            migrationBuilder.RenameIndex(
                name: "IX_dias_reservaId",
                table: "dias",
                newName: "IX_dias_idReserva");

            migrationBuilder.AddColumn<int>(
                name: "idBedel",
                table: "reserva",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idDia",
                table: "Aulas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reserva_idBedel",
                table: "reserva",
                column: "idBedel");

            migrationBuilder.CreateIndex(
                name: "IX_dias_idAula",
                table: "dias",
                column: "idAula",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dias_Aulas_idAula",
                table: "dias",
                column: "idAula",
                principalTable: "Aulas",
                principalColumn: "idAula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dias_reserva_idReserva",
                table: "dias",
                column: "idReserva",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reserva_Bedeles_idBedel",
                table: "reserva",
                column: "idBedel",
                principalTable: "Bedeles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dias_Aulas_idAula",
                table: "dias");

            migrationBuilder.DropForeignKey(
                name: "FK_dias_reserva_idReserva",
                table: "dias");

            migrationBuilder.DropForeignKey(
                name: "FK_reserva_Bedeles_idBedel",
                table: "reserva");

            migrationBuilder.DropIndex(
                name: "IX_reserva_idBedel",
                table: "reserva");

            migrationBuilder.DropIndex(
                name: "IX_dias_idAula",
                table: "dias");

            migrationBuilder.DropColumn(
                name: "idBedel",
                table: "reserva");

            migrationBuilder.DropColumn(
                name: "idDia",
                table: "Aulas");

            migrationBuilder.RenameColumn(
                name: "idReserva",
                table: "dias",
                newName: "reservaId");

            migrationBuilder.RenameIndex(
                name: "IX_dias_idReserva",
                table: "dias",
                newName: "IX_dias_reservaId");

            migrationBuilder.CreateIndex(
                name: "IX_dias_idAula",
                table: "dias",
                column: "idAula");

            migrationBuilder.AddForeignKey(
                name: "FK_dias_Aulas_idAula",
                table: "dias",
                column: "idAula",
                principalTable: "Aulas",
                principalColumn: "idAula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dias_reserva_reservaId",
                table: "dias",
                column: "reservaId",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
