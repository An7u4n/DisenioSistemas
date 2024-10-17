using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class usersadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    idAdministrador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    usuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.idAdministrador);
                });

            migrationBuilder.CreateTable(
                name: "Bedeles",
                columns: table => new
                {
                    idBedel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    turno = table.Column<string>(type: "TEXT", nullable: false),
                    usuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedeles", x => x.idBedel);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Bedeles");
        }
    }
}
