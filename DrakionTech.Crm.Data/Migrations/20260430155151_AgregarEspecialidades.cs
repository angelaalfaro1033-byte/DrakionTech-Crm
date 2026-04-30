using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_RolesUsuario_RolUsuarioId",
                        column: x => x.RolUsuarioId,
                        principalTable: "RolesUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_RolUsuarioId",
                table: "Especialidades",
                column: "RolUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
