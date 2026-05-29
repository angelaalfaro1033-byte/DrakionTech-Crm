using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthFieldsToEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: true),
                    RolNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Email",
                table: "Empleados",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_NumeroDocumento",
                table: "Empleados",
                column: "NumeroDocumento",
                unique: true,
                filter: "[NumeroDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EspecialidadId",
                table: "Empleados",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolUsuarioId",
                table: "Empleados",
                column: "RolUsuarioId");

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TemplateHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Activo", "Nombre", "TemplateHtml" },
                values: new object[] { 1, true, "ActivacionCuenta", "\r\n                <h1>Hola {{Nombre}}</h1>\r\n                <p>Haz clic en el siguiente enlace para activar tu cuenta:</p>\r\n                <a href='{{ActivationLink}}'>Activar cuenta</a>\r\n            " });

            migrationBuilder.CreateTable(
            name: "EmpleadoSalarios",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                EmpleadoId = table.Column<int>(type: "int", nullable: false),
                Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EmpleadoSalarios", x => x.Id);
                table.ForeignKey(
                    name: "FK_EmpleadoSalarios_Empleados_EmpleadoId",
                    column: x => x.EmpleadoId,
                    principalTable: "Empleados",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

                    migrationBuilder.CreateIndex(
                        name: "IX_EmpleadoSalarios_EmpleadoId",
                        table: "EmpleadoSalarios",
                        column: "EmpleadoId",
                        unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EmailTemplates");
            migrationBuilder.DropTable(name: "Empleados");
            migrationBuilder.DropTable(name: "EmpleadoSalarios");
        }
    }
}
