using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Servicio02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "ServicioMantenimientos");

            migrationBuilder.AddColumn<bool>(
                name: "Siniestro",
                table: "ServicioMantenimientos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Mantenimientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_ServicioId",
                table: "Mantenimientos",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Servicios_ServicioId",
                table: "Mantenimientos",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Servicios_ServicioId",
                table: "Mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_ServicioId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "Siniestro",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Mantenimientos");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "ServicioMantenimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
