using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class relacionesdias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dias_reserva_idReserva",
                table: "dias");

            migrationBuilder.DropIndex(
                name: "IX_dias_idReserva",
                table: "dias");

            migrationBuilder.DropColumn(
                name: "idReserva",
                table: "dias");

            migrationBuilder.AddColumn<int>(
                name: "DiaidDia",
                table: "reserva",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idReserva",
                table: "diasPeriodica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idReserva",
                table: "diasEsporadica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reserva_DiaidDia",
                table: "reserva",
                column: "DiaidDia");

            migrationBuilder.CreateIndex(
                name: "IX_diasPeriodica_idReserva",
                table: "diasPeriodica",
                column: "idReserva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_diasEsporadica_idReserva",
                table: "diasEsporadica",
                column: "idReserva",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_diasEsporadica_reservaEsporadicas_idReserva",
                table: "diasEsporadica",
                column: "idReserva",
                principalTable: "reservaEsporadicas",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_diasPeriodica_reservaPeriodicas_idReserva",
                table: "diasPeriodica",
                column: "idReserva",
                principalTable: "reservaPeriodicas",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reserva_dias_DiaidDia",
                table: "reserva",
                column: "DiaidDia",
                principalTable: "dias",
                principalColumn: "idDia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diasEsporadica_reservaEsporadicas_idReserva",
                table: "diasEsporadica");

            migrationBuilder.DropForeignKey(
                name: "FK_diasPeriodica_reservaPeriodicas_idReserva",
                table: "diasPeriodica");

            migrationBuilder.DropForeignKey(
                name: "FK_reserva_dias_DiaidDia",
                table: "reserva");

            migrationBuilder.DropIndex(
                name: "IX_reserva_DiaidDia",
                table: "reserva");

            migrationBuilder.DropIndex(
                name: "IX_diasPeriodica_idReserva",
                table: "diasPeriodica");

            migrationBuilder.DropIndex(
                name: "IX_diasEsporadica_idReserva",
                table: "diasEsporadica");

            migrationBuilder.DropColumn(
                name: "DiaidDia",
                table: "reserva");

            migrationBuilder.DropColumn(
                name: "idReserva",
                table: "diasPeriodica");

            migrationBuilder.DropColumn(
                name: "idReserva",
                table: "diasEsporadica");

            migrationBuilder.AddColumn<int>(
                name: "idReserva",
                table: "dias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_dias_idReserva",
                table: "dias",
                column: "idReserva",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dias_reserva_idReserva",
                table: "dias",
                column: "idReserva",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
