using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmpleadoConRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Especialidades_EspecialidadId",
                table: "Empleados",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_RolesUsuario_RolUsuarioId",
                table: "Empleados",
                column: "RolUsuarioId",
                principalTable: "RolesUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Especialidades_EspecialidadId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_RolesUsuario_RolUsuarioId",
                table: "Empleados");

            migrationBuilder.DropIndex(name: "IX_Empleados_EspecialidadId", table: "Empleados");
            migrationBuilder.DropIndex(name: "IX_Empleados_NumeroDocumento", table: "Empleados");
            migrationBuilder.DropIndex(name: "IX_Empleados_RolUsuarioId", table: "Empleados");
        }
    }
}
