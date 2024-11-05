using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarHerenciaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bedeles",
                table: "Bedeles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "Bedeles");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "Administradores");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Bedeles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Administradores",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "turno",
                table: "Bedeles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idBedel",
                table: "Bedeles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Bedeles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "idAdministrador",
                table: "Administradores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Administradores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bedeles",
                table: "Bedeles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contrasena = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    usuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bedeles_idBedel",
                table: "Bedeles",
                column: "idBedel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_idAdministrador",
                table: "Administradores",
                column: "idAdministrador",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Usuarios_id",
                table: "Administradores",
                column: "id",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Usuarios_idAdministrador",
                table: "Administradores",
                column: "idAdministrador",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bedeles_Usuarios_id",
                table: "Bedeles",
                column: "id",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bedeles_Usuarios_idBedel",
                table: "Bedeles",
                column: "idBedel",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Usuarios_id",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Usuarios_idAdministrador",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Bedeles_Usuarios_id",
                table: "Bedeles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bedeles_Usuarios_idBedel",
                table: "Bedeles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bedeles",
                table: "Bedeles");

            migrationBuilder.DropIndex(
                name: "IX_Bedeles_idBedel",
                table: "Bedeles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_idAdministrador",
                table: "Administradores");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bedeles",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Administradores",
                newName: "estado");

            migrationBuilder.AlterColumn<string>(
                name: "turno",
                table: "Bedeles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "idBedel",
                table: "Bedeles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Bedeles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "Bedeles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "idAdministrador",
                table: "Administradores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Administradores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "Administradores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bedeles",
                table: "Bedeles",
                column: "idBedel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores",
                column: "idAdministrador");
        }
    }
}
