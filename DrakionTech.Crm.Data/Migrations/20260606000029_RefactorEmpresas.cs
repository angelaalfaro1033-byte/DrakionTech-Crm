using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Estados_EstadoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Sectores_SectorId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_Nit",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_SectorId",
                table: "Empresas");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Empresas_Estado",
                table: "Empresas");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Empresas_Sector",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EstadoOtro",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Nit",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "SectorOtro",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Empresas",
                newName: "Tamaño");

            migrationBuilder.RenameColumn(
                name: "FechaVinculacion",
                table: "Empresas",
                newName: "FechaRegistroCrm");

            migrationBuilder.RenameColumn(
                name: "FechaEspecial",
                table: "Empresas",
                newName: "FechaCreacionEmpresa");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Empresas",
                newName: "SubsectorEmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_EstadoId",
                table: "Empresas",
                newName: "IX_Empresas_SubsectorEmpresaId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepresentanteLegal",
                table: "Empresas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empresas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empresas",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Empresas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activa",
                table: "Empresas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Empresas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Empresas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrefijoTelefonicoCodigo",
                table: "Empresas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrefijoTelefonicoId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectorEmpresaId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seguimiento",
                table: "Empresas",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoCliente",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumento",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsPrincipal",
                table: "Contactos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SectoresEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectoresEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubsectoresEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsectoresEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaCorreos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaCorreos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaCorreos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectorSubsector",
                columns: table => new
                {
                    SectoresId = table.Column<int>(type: "int", nullable: false),
                    SubsectoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSubsector", x => new { x.SectoresId, x.SubsectoresId });
                    table.ForeignKey(
                        name: "FK_SectorSubsector_SectoresEmpresa_SectoresId",
                        column: x => x.SectoresId,
                        principalTable: "SectoresEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectorSubsector_SubsectoresEmpresa_SubsectoresId",
                        column: x => x.SubsectoresId,
                        principalTable: "SubsectoresEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SectoresEmpresa",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Primario" },
                    { 2, "Manufactura" },
                    { 3, "Comercio" },
                    { 4, "Servicios" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SectorEmpresaId",
                table: "Empresas",
                column: "SectorEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_EmpresaId",
                table: "EmpresaCorreos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSubsector_SubsectoresId",
                table: "SectorSubsector",
                column: "SubsectoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_SectoresEmpresa_SectorEmpresaId",
                table: "Empresas",
                column: "SectorEmpresaId",
                principalTable: "SectoresEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_SubsectoresEmpresa_SubsectorEmpresaId",
                table: "Empresas",
                column: "SubsectorEmpresaId",
                principalTable: "SubsectoresEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Empresas_SectoresEmpresa_SectorEmpresaId", table: "Empresas");
            migrationBuilder.DropForeignKey(name: "FK_Empresas_SubsectoresEmpresa_SubsectorEmpresaId", table: "Empresas");
            migrationBuilder.DropTable(name: "EmpresaCorreos");
            migrationBuilder.DropTable(name: "SectorSubsector");
            migrationBuilder.DropTable(name: "SectoresEmpresa");
            migrationBuilder.DropTable(name: "SubsectoresEmpresa");
            migrationBuilder.DropIndex(name: "IX_Empresas_SectorEmpresaId", table: "Empresas");
            migrationBuilder.DropIndex(name: "IX_Empresas_SubsectorEmpresaId", table: "Empresas");
            migrationBuilder.DropColumn(name: "Descripcion", table: "Empresas");
            migrationBuilder.DropColumn(name: "NumeroDocumento", table: "Empresas");
            migrationBuilder.DropColumn(name: "PrefijoTelefonicoCodigo", table: "Empresas");
            migrationBuilder.DropColumn(name: "PrefijoTelefonicoId", table: "Empresas");
            migrationBuilder.DropColumn(name: "SectorEmpresaId", table: "Empresas");
            migrationBuilder.DropColumn(name: "Seguimiento", table: "Empresas");
            migrationBuilder.DropColumn(name: "TipoCliente", table: "Empresas");
            migrationBuilder.DropColumn(name: "TipoDocumento", table: "Empresas");
            migrationBuilder.DropColumn(name: "Cargo", table: "Contactos");
            migrationBuilder.DropColumn(name: "EsPrincipal", table: "Contactos");
            migrationBuilder.RenameColumn(name: "Tamaño", table: "Empresas", newName: "SectorId");
            migrationBuilder.RenameColumn(name: "SubsectorEmpresaId", table: "Empresas", newName: "EstadoId");
            migrationBuilder.RenameColumn(name: "FechaRegistroCrm", table: "Empresas", newName: "FechaVinculacion");
            migrationBuilder.RenameColumn(name: "FechaCreacionEmpresa", table: "Empresas", newName: "FechaEspecial");
            migrationBuilder.RenameIndex(name: "IX_Empresas_SubsectorEmpresaId", table: "Empresas", newName: "IX_Empresas_EstadoId");
        }
    }
}