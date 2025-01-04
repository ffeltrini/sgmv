using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ajustes01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MantenimientoId",
                table: "Mantenimientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepuestoUtilizados_MantenimientoId",
                table: "RepuestoUtilizados",
                column: "MantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_MantenimientoId",
                table: "Mantenimientos",
                column: "MantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Mantenimientos_MantenimientoId",
                table: "Mantenimientos",
                column: "MantenimientoId",
                principalTable: "Mantenimientos",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Mantenimientos_MantenimientoId",
                table: "Mantenimientos");

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
                name: "IX_Mantenimientos_MantenimientoId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "MantenimientoId",
                table: "RepuestoUtilizados");

            migrationBuilder.DropColumn(
                name: "MantenimientoId",
                table: "Mantenimientos");

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
    }
}
