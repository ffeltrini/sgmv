using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Servicio08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Siniestro",
                table: "ServicioMantenimientos");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProximoServicio",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Siniestro",
                table: "Servicios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fin",
                table: "ServicioMantenimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inicio",
                table: "ServicioMantenimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "ServicioMantenimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProximoServicio",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Siniestro",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Fin",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "Inicio",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "ServicioMantenimientos");

            migrationBuilder.AddColumn<bool>(
                name: "Siniestro",
                table: "ServicioMantenimientos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
