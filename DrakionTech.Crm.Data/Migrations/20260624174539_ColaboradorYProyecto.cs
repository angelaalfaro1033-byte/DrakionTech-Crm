using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColaboradorYProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpleadoProyectoAsignaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RolEnProyecto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoProyectoAsignaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpleadoProyectoAsignaciones_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpleadoProyectoAsignaciones_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpleadoProyectoAsignaciones_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpleadoProyectoAsignaciones_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoProyectoAsignaciones_CreatedByUserId",
                table: "EmpleadoProyectoAsignaciones",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoProyectoAsignaciones_Empleado_Activa",
                table: "EmpleadoProyectoAsignaciones",
                columns: new[] { "EmpleadoId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoProyectoAsignaciones_Empleado_Proyecto",
                table: "EmpleadoProyectoAsignaciones",
                columns: new[] { "EmpleadoId", "ProyectoId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoProyectoAsignaciones_ModifiedByUserId",
                table: "EmpleadoProyectoAsignaciones",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoProyectoAsignaciones_Proyecto_Activa",
                table: "EmpleadoProyectoAsignaciones",
                columns: new[] { "ProyectoId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "UX_EmpleadoProyectoAsignaciones_Activa",
                table: "EmpleadoProyectoAsignaciones",
                columns: new[] { "EmpleadoId", "ProyectoId", "Activa" },
                unique: true,
                filter: "[Activa] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoProyectoAsignaciones");
        }
    }
}
