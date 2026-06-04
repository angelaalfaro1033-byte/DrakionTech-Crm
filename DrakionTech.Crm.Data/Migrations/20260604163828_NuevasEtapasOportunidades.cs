using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class NuevasEtapasOportunidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OportunidadId1",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_OportunidadId1",
                table: "Proyectos",
                column: "OportunidadId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Oportunidades_OportunidadId1",
                table: "Proyectos",
                column: "OportunidadId1",
                principalTable: "Oportunidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Oportunidades_OportunidadId1",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_OportunidadId1",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "OportunidadId1",
                table: "Proyectos");
        }
    }
}
