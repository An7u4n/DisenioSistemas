using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class otramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
