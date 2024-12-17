using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class diaSemanaMovidoDeEntidad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaSemana",
                table: "Dias");

            migrationBuilder.AddColumn<int>(
                name: "diaSemana",
                table: "DiasPeriodica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaSemana",
                table: "DiasPeriodica");

            migrationBuilder.AddColumn<int>(
                name: "diaSemana",
                table: "Dias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
