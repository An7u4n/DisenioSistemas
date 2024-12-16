using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class CambiarFechaInicioYFinADateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica");

            migrationBuilder.CreateIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica",
                column: "idReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica");

            migrationBuilder.CreateIndex(
                name: "IX_DiasEsporadica_idReserva",
                table: "DiasEsporadica",
                column: "idReserva",
                unique: true);
        }
    }
}
