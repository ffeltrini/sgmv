using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TipoRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoRol_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoRol",
                table: "TipoRol");

            migrationBuilder.RenameTable(
                name: "TipoRol",
                newName: "TipoRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoRoles",
                table: "TipoRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoRoles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "TipoRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoRoles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoRoles",
                table: "TipoRoles");

            migrationBuilder.RenameTable(
                name: "TipoRoles",
                newName: "TipoRol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoRol",
                table: "TipoRol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoRol_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "TipoRol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
