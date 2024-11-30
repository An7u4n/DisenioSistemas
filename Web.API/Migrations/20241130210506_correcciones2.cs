using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.API.Migrations
{
    /// <inheritdoc />
    public partial class correcciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuatrimestres_AnioLectivos_idAnio",
                table: "Cuatrimestres");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaEsporadicas_reserva_idReserva",
                table: "reservaEsporadicas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaPeriodicas_Cuatrimestres_idCuatrimestre",
                table: "reservaPeriodicas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaPeriodicas_reserva_idReserva",
                table: "reservaPeriodicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuatrimestres",
                table: "Cuatrimestres");

            migrationBuilder.DropColumn(
                name: "idReservaPeriodica",
                table: "diasPeriodica");

            migrationBuilder.DropColumn(
                name: "idResevaPeriodica",
                table: "diasEsporadica");

            migrationBuilder.RenameTable(
                name: "Cuatrimestres",
                newName: "Cuatrimestre");

            migrationBuilder.RenameColumn(
                name: "idReserva",
                table: "reservaPeriodicas",
                newName: "idReservaPeriodica");

            migrationBuilder.RenameColumn(
                name: "idReserva",
                table: "reservaEsporadicas",
                newName: "idReservaPeriodica");

            migrationBuilder.RenameColumn(
                name: "idReserva",
                table: "reserva",
                newName: "idReservaPeriodica");

            migrationBuilder.RenameIndex(
                name: "IX_Cuatrimestres_idAnio",
                table: "Cuatrimestre",
                newName: "IX_Cuatrimestre_idAnio");

            migrationBuilder.AddColumn<int>(
                name: "reservaId",
                table: "dias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuatrimestre",
                table: "Cuatrimestre",
                column: "idCuatrimestre");

            migrationBuilder.CreateIndex(
                name: "IX_dias_reservaId",
                table: "dias",
                column: "reservaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_idAnio",
                table: "Cuatrimestre",
                column: "idAnio",
                principalTable: "AnioLectivos",
                principalColumn: "IdAnioLectivo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dias_reserva_reservaId",
                table: "dias",
                column: "reservaId",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaEsporadicas_reserva_idReservaPeriodica",
                table: "reservaEsporadicas",
                column: "idReservaPeriodica",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaPeriodicas_Cuatrimestre_idCuatrimestre",
                table: "reservaPeriodicas",
                column: "idCuatrimestre",
                principalTable: "Cuatrimestre",
                principalColumn: "idCuatrimestre",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaPeriodicas_reserva_idReservaPeriodica",
                table: "reservaPeriodicas",
                column: "idReservaPeriodica",
                principalTable: "reserva",
                principalColumn: "idReservaPeriodica",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuatrimestre_AnioLectivos_idAnio",
                table: "Cuatrimestre");

            migrationBuilder.DropForeignKey(
                name: "FK_dias_reserva_reservaId",
                table: "dias");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaEsporadicas_reserva_idReservaPeriodica",
                table: "reservaEsporadicas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaPeriodicas_Cuatrimestre_idCuatrimestre",
                table: "reservaPeriodicas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaPeriodicas_reserva_idReservaPeriodica",
                table: "reservaPeriodicas");

            migrationBuilder.DropIndex(
                name: "IX_dias_reservaId",
                table: "dias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuatrimestre",
                table: "Cuatrimestre");

            migrationBuilder.DropColumn(
                name: "reservaId",
                table: "dias");

            migrationBuilder.RenameTable(
                name: "Cuatrimestre",
                newName: "Cuatrimestres");

            migrationBuilder.RenameColumn(
                name: "idReservaPeriodica",
                table: "reservaPeriodicas",
                newName: "idReserva");

            migrationBuilder.RenameColumn(
                name: "idReservaPeriodica",
                table: "reservaEsporadicas",
                newName: "idReserva");

            migrationBuilder.RenameColumn(
                name: "idReservaPeriodica",
                table: "reserva",
                newName: "idReserva");

            migrationBuilder.RenameIndex(
                name: "IX_Cuatrimestre_idAnio",
                table: "Cuatrimestres",
                newName: "IX_Cuatrimestres_idAnio");

            migrationBuilder.AddColumn<int>(
                name: "idReservaPeriodica",
                table: "diasPeriodica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idResevaPeriodica",
                table: "diasEsporadica",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuatrimestres",
                table: "Cuatrimestres",
                column: "idCuatrimestre");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuatrimestres_AnioLectivos_idAnio",
                table: "Cuatrimestres",
                column: "idAnio",
                principalTable: "AnioLectivos",
                principalColumn: "IdAnioLectivo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaEsporadicas_reserva_idReserva",
                table: "reservaEsporadicas",
                column: "idReserva",
                principalTable: "reserva",
                principalColumn: "idReserva",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaPeriodicas_Cuatrimestres_idCuatrimestre",
                table: "reservaPeriodicas",
                column: "idCuatrimestre",
                principalTable: "Cuatrimestres",
                principalColumn: "idCuatrimestre",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaPeriodicas_reserva_idReserva",
                table: "reservaPeriodicas",
                column: "idReserva",
                principalTable: "reserva",
                principalColumn: "idReserva",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
