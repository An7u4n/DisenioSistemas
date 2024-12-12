using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class checkmigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Dias_DiaidDia",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_DiaidDia",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DiaidDia",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "ReservaidReserva",
                table: "Dias",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dias_ReservaidReserva",
                table: "Dias",
                column: "ReservaidReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Dias_Reservas_ReservaidReserva",
                table: "Dias",
                column: "ReservaidReserva",
                principalTable: "Reservas",
                principalColumn: "idReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dias_Reservas_ReservaidReserva",
                table: "Dias");

            migrationBuilder.DropIndex(
                name: "IX_Dias_ReservaidReserva",
                table: "Dias");

            migrationBuilder.DropColumn(
                name: "ReservaidReserva",
                table: "Dias");

            migrationBuilder.AddColumn<int>(
                name: "DiaidDia",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_DiaidDia",
                table: "Reservas",
                column: "DiaidDia");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Dias_DiaidDia",
                table: "Reservas",
                column: "DiaidDia",
                principalTable: "Dias",
                principalColumn: "idDia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
