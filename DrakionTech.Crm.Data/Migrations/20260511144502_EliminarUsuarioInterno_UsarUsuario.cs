using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class EliminarUsuarioInterno_UsarUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadUsuarios_UsuarioInterno_UsuarioInternoId",
                table: "ActividadUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActividadUsuarios",
                table: "ActividadUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_UsuarioInternoId_Inicio_Fin",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioInternoId",
                table: "ActividadUsuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "ActividadUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioInternoId",
                table: "Actividades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActividadUsuarios",
                table: "ActividadUsuarios",
                columns: new[] { "ActividadId", "UsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_UsuarioId",
                table: "ActividadUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioId",
                table: "Actividades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioId_Inicio_Fin",
                table: "Actividades",
                columns: new[] { "UsuarioId", "Inicio", "Fin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                table: "Actividades",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Usuarios_UsuarioId",
                table: "Actividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadUsuarios_UsuarioInterno_UsuarioInternoId",
                table: "ActividadUsuarios",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_UsuarioId",
                table: "ActividadUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Usuarios_UsuarioId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadUsuarios_UsuarioInterno_UsuarioInternoId",
                table: "ActividadUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_UsuarioId",
                table: "ActividadUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActividadUsuarios",
                table: "ActividadUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_ActividadUsuarios_UsuarioId",
                table: "ActividadUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_UsuarioId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_UsuarioId_Inicio_Fin",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ActividadUsuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioInternoId",
                table: "ActividadUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioInternoId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActividadUsuarios",
                table: "ActividadUsuarios",
                columns: new[] { "ActividadId", "UsuarioInternoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioInternoId_Inicio_Fin",
                table: "Actividades",
                columns: new[] { "UsuarioInternoId", "Inicio", "Fin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                table: "Actividades",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadUsuarios_UsuarioInterno_UsuarioInternoId",
                table: "ActividadUsuarios",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
