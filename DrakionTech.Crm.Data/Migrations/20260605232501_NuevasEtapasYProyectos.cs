using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class NuevasEtapasYProyectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Soporte",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordatorioPago",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtapaFlujo",
                table: "Proyectos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EquipoTrabajo",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentosUrl",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimaModificacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagado",
                table: "Proyectos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PresupuestoTotal",
                table: "Proyectos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_SupervisorId",
                table: "Proyectos",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos",
                column: "SupervisorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_SupervisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(name: "Soporte", table: "Proyectos");
            migrationBuilder.DropColumn(name: "RecordatorioPago", table: "Proyectos");
            migrationBuilder.DropColumn(name: "Observaciones", table: "Proyectos");
            migrationBuilder.DropColumn(name: "EtapaFlujo", table: "Proyectos");
            migrationBuilder.DropColumn(name: "EquipoTrabajo", table: "Proyectos");
            migrationBuilder.DropColumn(name: "DocumentosUrl", table: "Proyectos");
            migrationBuilder.DropColumn(name: "SupervisorId", table: "Proyectos");
            migrationBuilder.DropColumn(name: "FechaCreacion", table: "Proyectos");
            migrationBuilder.DropColumn(name: "FechaPago", table: "Proyectos");
            migrationBuilder.DropColumn(name: "FechaUltimaModificacion", table: "Proyectos");
            migrationBuilder.DropColumn(name: "MontoPagado", table: "Proyectos");
            migrationBuilder.DropColumn(name: "PresupuestoTotal", table: "Proyectos");
        }
    }
}
