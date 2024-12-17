using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class cambioIdAnioLectivoEnCuatrimestre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre");

            migrationBuilder.RenameColumn(
                name: "AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                newName: "anioLectivoIdAnioLectivo");

            migrationBuilder.RenameIndex(
                name: "IX_Cuatrimestre_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                newName: "IX_Cuatrimestre_anioLectivoIdAnioLectivo");

            migrationBuilder.AlterColumn<int>(
                name: "idAnio",
                table: "Cuatrimestre",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "anioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_anioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                column: "anioLectivoIdAnioLectivo",
                principalTable: "AnioLectivos",
                principalColumn: "IdAnioLectivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_anioLectivoIdAnioLectivo",
                table: "Cuatrimestre");

            migrationBuilder.RenameColumn(
                name: "anioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                newName: "AnioLectivoIdAnioLectivo");

            migrationBuilder.RenameIndex(
                name: "IX_Cuatrimestre_anioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                newName: "IX_Cuatrimestre_AnioLectivoIdAnioLectivo");

            migrationBuilder.AlterColumn<int>(
                name: "idAnio",
                table: "Cuatrimestre",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_AnioLectivoIdAnioLectivo",
                table: "Cuatrimestre",
                column: "AnioLectivoIdAnioLectivo",
                principalTable: "AnioLectivos",
                principalColumn: "IdAnioLectivo");
        }
    }
}
