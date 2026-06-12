using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMarketingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicacionesMarketing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescripcionCampania = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CopyUtilizado = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ResponsableId = table.Column<int>(type: "int", nullable: false),
                    FechaPublicacionProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPublicacionReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnvioAutomatico = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Recordatorio3DiasEnviado = table.Column<bool>(type: "bit", nullable: false),
                    RecordatorioDiaPublicacionEnviado = table.Column<bool>(type: "bit", nullable: false),
                    AlertaRetrasoEnviada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesMarketing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionesMarketing_Usuarios_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosPublicacionMarketing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionMarketingId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchivoIdExterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosPublicacionMarketing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivosPublicacionMarketing_PublicacionesMarketing_PublicacionMarketingId",
                        column: x => x.PublicacionMarketingId,
                        principalTable: "PublicacionesMarketing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetricasPublicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionMarketingId = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visualizaciones = table.Column<int>(type: "int", nullable: false),
                    Reacciones = table.Column<int>(type: "int", nullable: false),
                    Alcance = table.Column<int>(type: "int", nullable: false),
                    ContactoAreaComercial = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricasPublicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricasPublicacion_PublicacionesMarketing_PublicacionMarketingId",
                        column: x => x.PublicacionMarketingId,
                        principalTable: "PublicacionesMarketing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionRedesSociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionMarketingId = table.Column<int>(type: "int", nullable: false),
                    RedSocial = table.Column<int>(type: "int", nullable: false),
                    TienePauta = table.Column<bool>(type: "bit", nullable: false),
                    CostoPauta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiasPauta = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionRedesSociales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionRedesSociales_PublicacionesMarketing_PublicacionMarketingId",
                        column: x => x.PublicacionMarketingId,
                        principalTable: "PublicacionesMarketing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_PublicacionMarketingId",
                table: "ArchivosPublicacionMarketing",
                column: "PublicacionMarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_PublicacionMarketingId",
                table: "MetricasPublicacion",
                column: "PublicacionMarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_ResponsableId",
                table: "PublicacionesMarketing",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_PublicacionMarketingId_RedSocial",
                table: "PublicacionRedesSociales",
                columns: new[] { "PublicacionMarketingId", "RedSocial" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosPublicacionMarketing");

            migrationBuilder.DropTable(
                name: "MetricasPublicacion");

            migrationBuilder.DropTable(
                name: "PublicacionRedesSociales");

            migrationBuilder.DropTable(
                name: "PublicacionesMarketing");
        }
    }
}
