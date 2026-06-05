using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorProyect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Oportunidades_OportunidadId1",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "OportunidadId1",
                table: "Proyectos",
                newName: "SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Proyectos_OportunidadId1",
                table: "Proyectos",
                newName: "IX_Proyectos_SupervisorId");

            migrationBuilder.AddColumn<string>(
                name: "DocumentosUrl",
                table: "Proyectos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipoTrabajo",
                table: "Proyectos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtapaFlujo",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FasesJson",
                table: "Proyectos",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Proyectos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PresupuestoTotal",
                table: "Proyectos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordatorioPago",
                table: "Proyectos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soporte",
                table: "Proyectos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos",
                column: "SupervisorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "DocumentosUrl",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "EquipoTrabajo",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "EtapaFlujo",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "FasesJson",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "FechaUltimaModificacion",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "PresupuestoTotal",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "RecordatorioPago",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Soporte",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "Proyectos",
                newName: "OportunidadId1");

            migrationBuilder.RenameIndex(
                name: "IX_Proyectos_SupervisorId",
                table: "Proyectos",
                newName: "IX_Proyectos_OportunidadId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Oportunidades_OportunidadId1",
                table: "Proyectos",
                column: "OportunidadId1",
                principalTable: "Oportunidades",
                principalColumn: "Id");
        }
    }
}
