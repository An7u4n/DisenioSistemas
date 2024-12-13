using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class reservaperiodicatienevariosdias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiasPeriodica_idReserva",
                table: "DiasPeriodica");

            migrationBuilder.CreateIndex(
                name: "IX_DiasPeriodica_idReserva",
                table: "DiasPeriodica",
                column: "idReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiasPeriodica_idReserva",
                table: "DiasPeriodica");

            migrationBuilder.CreateIndex(
                name: "IX_DiasPeriodica_idReserva",
                table: "DiasPeriodica",
                column: "idReserva",
                unique: true);
        }
    }
}
