using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActividadesRelacionadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadoActividad",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "ActividadPreviaId",
                table: "Actividades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ActividadPreviaId",
                table: "Actividades",
                column: "ActividadPreviaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Actividades_ActividadPreviaId",
                table: "Actividades",
                column: "ActividadPreviaId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Actividades_ActividadPreviaId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_ActividadPreviaId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "ActividadPreviaId",
                table: "Actividades");

            migrationBuilder.InsertData(
                table: "EstadoActividad",
                columns: new[] { "Id", "Activo", "Nombre" },
                values: new object[] { 3, true, "Cancelada" });
        }
    }
}
