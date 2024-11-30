using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class correcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diasEsporadica_reservaEsporadicas_reservaEsporadicaidReserva",
                table: "diasEsporadica");

            migrationBuilder.DropForeignKey(
                name: "FK_diasPeriodica_reservaPeriodicas_reservaPeriodicaidReserva",
                table: "diasPeriodica");

            migrationBuilder.DropIndex(
                name: "IX_diasPeriodica_reservaPeriodicaidReserva",
                table: "diasPeriodica");

            migrationBuilder.DropIndex(
                name: "IX_diasEsporadica_reservaEsporadicaidReserva",
                table: "diasEsporadica");

            migrationBuilder.DropColumn(
                name: "idResevaPeriodica",
                table: "diasPeriodica");

            migrationBuilder.DropColumn(
                name: "reservaEsporadicaidReserva",
                table: "diasEsporadica");

            migrationBuilder.RenameColumn(
                name: "reservaPeriodicaidReserva",
                table: "diasPeriodica",
                newName: "idReservaPeriodica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idReservaPeriodica",
                table: "diasPeriodica",
                newName: "reservaPeriodicaidReserva");

            migrationBuilder.AddColumn<int>(
                name: "idResevaPeriodica",
                table: "diasPeriodica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reservaEsporadicaidReserva",
                table: "diasEsporadica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_diasPeriodica_reservaPeriodicaidReserva",
                table: "diasPeriodica",
                column: "reservaPeriodicaidReserva");

            migrationBuilder.CreateIndex(
                name: "IX_diasEsporadica_reservaEsporadicaidReserva",
                table: "diasEsporadica",
                column: "reservaEsporadicaidReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_diasEsporadica_reservaEsporadicas_reservaEsporadicaidReserva",
                table: "diasEsporadica",
                column: "reservaEsporadicaidReserva",
                principalTable: "reservaEsporadicas",
                principalColumn: "idReserva",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_diasPeriodica_reservaPeriodicas_reservaPeriodicaidReserva",
                table: "diasPeriodica",
                column: "reservaPeriodicaidReserva",
                principalTable: "reservaPeriodicas",
                principalColumn: "idReserva",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
