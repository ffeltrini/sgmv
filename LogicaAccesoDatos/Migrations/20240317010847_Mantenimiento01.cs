using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Mantenimiento01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "Mantenimientos",
                newName: "DuracionMinutos");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DuracionHoras",
                table: "Mantenimientos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuracionHoras",
                table: "Mantenimientos");

            migrationBuilder.RenameColumn(
                name: "DuracionMinutos",
                table: "Mantenimientos",
                newName: "Duracion");
        }
    }
}
