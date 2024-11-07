using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class agregadasTablasDeAulas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numero = table.Column<int>(type: "INTEGER", nullable: false),
                    piso = table.Column<int>(type: "INTEGER", nullable: false),
                    aireAcondicionado = table.Column<bool>(type: "INTEGER", nullable: false),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    tipoDePizarron = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.idAula);
                });

            migrationBuilder.CreateTable(
                name: "AulasInformatica",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    canion = table.Column<bool>(type: "INTEGER", nullable: false),
                    cantidadComputadoras = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasInformatica", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasInformatica_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AulasMultimedios",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    canion = table.Column<bool>(type: "INTEGER", nullable: false),
                    cantidadComputadoras = table.Column<int>(type: "INTEGER", nullable: false),
                    poseeVentiladores = table.Column<bool>(type: "INTEGER", nullable: false),
                    televisor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasMultimedios", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasMultimedios_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AulasSinRecursosAdicionales",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    poseeVentiladores = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasSinRecursosAdicionales", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_AulasSinRecursosAdicionales_Aulas_idAula",
                        column: x => x.idAula,
                        principalTable: "Aulas",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulasInformatica");

            migrationBuilder.DropTable(
                name: "AulasMultimedios");

            migrationBuilder.DropTable(
                name: "AulasSinRecursosAdicionales");

            migrationBuilder.DropTable(
                name: "Aulas");
        }
    }
}
