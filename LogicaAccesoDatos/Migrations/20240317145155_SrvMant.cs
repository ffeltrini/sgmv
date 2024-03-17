using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class SrvMant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimiento_TipoMantenimiento_TipoMantenimientoId",
                table: "ServicioMantenimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoMantenimiento",
                table: "TipoMantenimiento");

            migrationBuilder.RenameTable(
                name: "TipoMantenimiento",
                newName: "TipoMantenimientos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoMantenimientos",
                table: "TipoMantenimientos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimiento_TipoMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimiento",
                column: "TipoMantenimientoId",
                principalTable: "TipoMantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimiento_TipoMantenimientos_TipoMantenimientoId",
                table: "ServicioMantenimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoMantenimientos",
                table: "TipoMantenimientos");

            migrationBuilder.RenameTable(
                name: "TipoMantenimientos",
                newName: "TipoMantenimiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoMantenimiento",
                table: "TipoMantenimiento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimiento_TipoMantenimiento_TipoMantenimientoId",
                table: "ServicioMantenimiento",
                column: "TipoMantenimientoId",
                principalTable: "TipoMantenimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
