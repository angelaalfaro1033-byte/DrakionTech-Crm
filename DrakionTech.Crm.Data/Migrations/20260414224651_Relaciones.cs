using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "GoogleEventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpresaNit",
                table: "GoogleEventos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpresaNombre",
                table: "GoogleEventos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "EmpresaNit",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "EmpresaNombre",
                table: "GoogleEventos");
        }
    }
}
