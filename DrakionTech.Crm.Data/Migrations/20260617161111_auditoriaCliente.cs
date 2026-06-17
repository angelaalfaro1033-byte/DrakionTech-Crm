using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class auditoriaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TipoEvento = table.Column<int>(type: "int", nullable: false),
                    TituloEvento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescripcionEvento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioResponsableId = table.Column<int>(type: "int", nullable: true),
                    UsuarioResponsableNombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModuloOrigen = table.Column<int>(type: "int", nullable: false),
                    RegistroOrigenId = table.Column<int>(type: "int", nullable: true),
                    DatosAdicionales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaveEvento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialEmpresas_Usuarios_UsuarioResponsableId",
                        column: x => x.UsuarioResponsableId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpresas_ClaveEvento",
                table: "HistorialEmpresas",
                column: "ClaveEvento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpresas_EmpresaId_FechaEvento",
                table: "HistorialEmpresas",
                columns: new[] { "EmpresaId", "FechaEvento" });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpresas_EmpresaId_ModuloOrigen_FechaEvento",
                table: "HistorialEmpresas",
                columns: new[] { "EmpresaId", "ModuloOrigen", "FechaEvento" });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpresas_EmpresaId_TipoEvento_FechaEvento",
                table: "HistorialEmpresas",
                columns: new[] { "EmpresaId", "TipoEvento", "FechaEvento" });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpresas_UsuarioResponsableId",
                table: "HistorialEmpresas",
                column: "UsuarioResponsableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialEmpresas");
        }
    }
}
