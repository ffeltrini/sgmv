using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repuestos_ServicioMantenimientos_ServicioMantenimientoId",
                table: "Repuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_RepuestoUtilizados_Mantenimientos_MantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.DropForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.DropIndex(
                name: "IX_RepuestoUtilizados_MantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.DropIndex(
                name: "IX_Repuestos_ServicioMantenimientoId",
                table: "Repuestos");

            migrationBuilder.DropColumn(
                name: "MantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.DropColumn(
                name: "ServicioMantenimientoId",
                table: "Repuestos");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioMantenimientoId",
                table: "RepuestoUtilizados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId",
                table: "RepuestoUtilizados",
                column: "ServicioMantenimientoId",
                principalTable: "ServicioMantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioMantenimientoId",
                table: "RepuestoUtilizados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MantenimientoId",
                table: "RepuestoUtilizados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicioMantenimientoId",
                table: "Repuestos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepuestoUtilizados_MantenimientoId",
                table: "RepuestoUtilizados",
                column: "MantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Repuestos_ServicioMantenimientoId",
                table: "Repuestos",
                column: "ServicioMantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repuestos_ServicioMantenimientos_ServicioMantenimientoId",
                table: "Repuestos",
                column: "ServicioMantenimientoId",
                principalTable: "ServicioMantenimientos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepuestoUtilizados_Mantenimientos_MantenimientoId",
                table: "RepuestoUtilizados",
                column: "MantenimientoId",
                principalTable: "Mantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId",
                table: "RepuestoUtilizados",
                column: "ServicioMantenimientoId",
                principalTable: "ServicioMantenimientos",
                principalColumn: "Id");
        }
    }
}
