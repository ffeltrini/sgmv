using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ServicioMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicioMantenimientoId1",
                table: "RepuestoUtilizados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepuestoUtilizados_ServicioMantenimientoId1",
                table: "RepuestoUtilizados",
                column: "ServicioMantenimientoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId1",
                table: "RepuestoUtilizados",
                column: "ServicioMantenimientoId1",
                principalTable: "ServicioMantenimientos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepuestoUtilizados_ServicioMantenimientos_ServicioMantenimientoId1",
                table: "RepuestoUtilizados");

            migrationBuilder.DropIndex(
                name: "IX_RepuestoUtilizados_ServicioMantenimientoId1",
                table: "RepuestoUtilizados");

            migrationBuilder.DropColumn(
                name: "ServicioMantenimientoId1",
                table: "RepuestoUtilizados");
        }
    }
}
