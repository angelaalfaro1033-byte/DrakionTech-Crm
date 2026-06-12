using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class PagosProyectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "RecordatorioPago",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "Proyectos",
                newName: "SupervisorInternoId");

            migrationBuilder.RenameIndex(
                name: "IX_Proyectos_SupervisorId",
                table: "Proyectos",
                newName: "IX_Proyectos_SupervisorInternoId");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorExternoId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PagosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiasAnticipacionRecordatorio = table.Column<int>(type: "int", nullable: true),
                    DescripcionRecordatorio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagosProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_SupervisorExternoId",
                table: "Proyectos",
                column: "SupervisorExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosProyecto_ProyectoId",
                table: "PagosProyecto",
                column: "ProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Contactos_SupervisorExternoId",
                table: "Proyectos",
                column: "SupervisorExternoId",
                principalTable: "Contactos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorInternoId",
                table: "Proyectos",
                column: "SupervisorInternoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Contactos_SupervisorExternoId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorInternoId",
                table: "Proyectos");

            migrationBuilder.DropTable(
                name: "PagosProyecto");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_SupervisorExternoId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "SupervisorExternoId",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "SupervisorInternoId",
                table: "Proyectos",
                newName: "SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Proyectos_SupervisorInternoId",
                table: "Proyectos",
                newName: "IX_Proyectos_SupervisorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagado",
                table: "Proyectos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordatorioPago",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos",
                column: "SupervisorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
