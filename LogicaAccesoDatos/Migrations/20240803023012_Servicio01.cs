using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Servicio01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimientos_Etapas_EtapaId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimientos_TipoMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_ServicioMantenimientos_EtapaId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_ServicioMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "EtapaId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "FechaProxMant",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "Siniestro",
                table: "ServicioMantenimientos");

            migrationBuilder.DropColumn(
                name: "TipoMantenimientoId",
                table: "ServicioMantenimientos");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioMantenimientos_MantenimientoId",
                table: "ServicioMantenimientos",
                column: "MantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimientos_Mantenimientos_MantenimientoId",
                table: "ServicioMantenimientos",
                column: "MantenimientoId",
                principalTable: "Mantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimientos_Mantenimientos_MantenimientoId",
                table: "ServicioMantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_ServicioMantenimientos_MantenimientoId",
                table: "ServicioMantenimientos");

            migrationBuilder.AddColumn<int>(
                name: "EtapaId",
                table: "ServicioMantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "ServicioMantenimientos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaProxMant",
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

            migrationBuilder.AddColumn<bool>(
                name: "Siniestro",
                table: "ServicioMantenimientos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoMantenimientoId",
                table: "ServicioMantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServicioMantenimientos_EtapaId",
                table: "ServicioMantenimientos",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimientos",
                column: "TipoMantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimientos_Etapas_EtapaId",
                table: "ServicioMantenimientos",
                column: "EtapaId",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimientos_TipoMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimientos",
                column: "TipoMantenimientoId",
                principalTable: "TipoMantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
