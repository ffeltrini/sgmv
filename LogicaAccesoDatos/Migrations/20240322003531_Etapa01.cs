using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Etapa01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimiento_Etapa_EtapaId",
                table: "ServicioMantenimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etapa",
                table: "Etapa");

            migrationBuilder.RenameTable(
                name: "Etapa",
                newName: "Etapas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Etapas",
                newName: "EtapaNombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimiento_Etapas_EtapaId",
                table: "ServicioMantenimiento",
                column: "EtapaId",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMantenimiento_Etapas_EtapaId",
                table: "ServicioMantenimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas");

            migrationBuilder.RenameTable(
                name: "Etapas",
                newName: "Etapa");

            migrationBuilder.RenameColumn(
                name: "EtapaNombre",
                table: "Etapa",
                newName: "Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etapa",
                table: "Etapa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMantenimiento_Etapa_EtapaId",
                table: "ServicioMantenimiento",
                column: "EtapaId",
                principalTable: "Etapa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
