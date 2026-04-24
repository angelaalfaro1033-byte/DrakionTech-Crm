using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoActividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIso = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesContacto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioInterno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioInterno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrefijosTelefonicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefijosTelefonicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrefijosTelefonicos_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    SectorOtro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    EstadoOtro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RepresentanteLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVinculacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HaTrabajadoAntes = table.Column<bool>(type: "bit", nullable: false),
                    FechaEspecial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.CheckConstraint("CK_Empresas_Estado", "(\r\n                        (EstadoId IS NOT NULL AND EstadoOtro IS NULL)\r\n                        OR\r\n                        (EstadoId IS NULL AND LTRIM(RTRIM(EstadoOtro)) <> '')\r\n                    )");
                    table.CheckConstraint("CK_Empresas_Sector", "(\r\n                        (SectorId IS NOT NULL AND SectorOtro IS NULL)\r\n                        OR\r\n                        (SectorId IS NULL AND LTRIM(RTRIM(SectorOtro)) <> '')\r\n                    )");
                    table.ForeignKey(
                        name: "FK_Empresas_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolContactoId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FechaVinculacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEspecial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contactos_RolesContacto_RolContactoId",
                        column: x => x.RolContactoId,
                        principalTable: "RolesContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProyecto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ValorEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Etapa = table.Column<int>(type: "int", nullable: false),
                    FechaEstimadaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ContactoPrincipalId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oportunidades_Contactos_ContactoPrincipalId",
                        column: x => x.ContactoPrincipalId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Oportunidades_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoActividadId = table.Column<int>(type: "int", nullable: false),
                    EstadoActividadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioInternoId = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resultado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ExternalCalendarEventId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    ContactoId = table.Column<int>(type: "int", nullable: true),
                    OportunidadId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_EstadoActividad_EstadoActividadId",
                        column: x => x.EstadoActividadId,
                        principalTable: "EstadoActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_TipoActividad_TipoActividadId",
                        column: x => x.TipoActividadId,
                        principalTable: "TipoActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                        column: x => x.UsuarioInternoId,
                        principalTable: "UsuarioInterno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialCambiosOportunidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OportunidadId = table.Column<int>(type: "int", nullable: false),
                    EtapaAnterior = table.Column<int>(type: "int", nullable: false),
                    EtapaNueva = table.Column<int>(type: "int", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCambiosOportunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialCambiosOportunidad_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OportunidadId = table.Column<int>(type: "int", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TipoContenido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TamanoArchivo = table.Column<long>(type: "bigint", nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propuestas_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadUsuarios",
                columns: table => new
                {
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioInternoId = table.Column<int>(type: "int", nullable: false),
                    EsResponsable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadUsuarios", x => new { x.ActividadId, x.UsuarioInternoId });
                    table.ForeignKey(
                        name: "FK_ActividadUsuarios_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadUsuarios_UsuarioInterno_UsuarioInternoId",
                        column: x => x.UsuarioInternoId,
                        principalTable: "UsuarioInterno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EstadoActividad",
                columns: new[] { "Id", "Activo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Programada" },
                    { 2, true, "Completada" },
                    { 3, true, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Lead" },
                    { 2, "Prospecto" },
                    { 3, "Cliente" },
                    { 4, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "CodigoIso", "Nombre" },
                values: new object[,]
                {
                    { 1, "CO", "Colombia" },
                    { 2, "EEUU", "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "RolesContacto",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Desconocido" },
                    { 2, "CEO" },
                    { 3, "CTO" },
                    { 4, "CFO" },
                    { 5, "COO" },
                    { 6, "Director" },
                    { 7, "Gerente" },
                    { 8, "Project Manager" },
                    { 9, "Líder Técnico" },
                    { 10, "Recursos Humanos" },
                    { 11, "Compras" },
                    { 12, "Ventas" },
                    { 13, "Marketing" },
                    { 14, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Educación" },
                    { 3, "Retail Comercio" },
                    { 4, "Logística y Transporte" },
                    { 5, "Inmobiliario" },
                    { 6, "Finanzas" },
                    { 7, "Manufactura" },
                    { 8, "Servicios Profesionales" },
                    { 9, "Gobierno / Sector Público" },
                    { 10, "Construcción" },
                    { 11, "Turismo y Hospitalidad" },
                    { 12, "Agricultura / Agroindustria" },
                    { 13, "Energía" },
                    { 14, "Tecnología" }
                });

            migrationBuilder.InsertData(
                table: "TipoActividad",
                columns: new[] { "Id", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Llamada telefónica con el cliente", "Llamada" },
                    { 2, true, "Reunión presencial o virtual", "Reunión" },
                    { 3, true, "Envío o seguimiento vía correo electrónico", "Correo" },
                    { 4, true, "Seguimiento comercial", "Seguimiento" },
                    { 5, true, "Demostración de producto o servicio", "Demo" }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 101, "Bogotá", 1 },
                    { 102, "Medellín", 1 },
                    { 201, "Nueva York", 2 }
                });

            migrationBuilder.InsertData(
                table: "PrefijosTelefonicos",
                columns: new[] { "Id", "Codigo", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "+57", "Colombia", 1 },
                    { 2, "+1", "Estados Unidos", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ContactoId",
                table: "Actividades",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_EmpresaId",
                table: "Actividades",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_EstadoActividadId",
                table: "Actividades",
                column: "EstadoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_Inicio",
                table: "Actividades",
                column: "Inicio");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_OportunidadId",
                table: "Actividades",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TipoActividadId",
                table: "Actividades",
                column: "TipoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioInternoId",
                table: "Actividades",
                column: "UsuarioInternoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioInternoId_Inicio_Fin",
                table: "Actividades",
                columns: new[] { "UsuarioInternoId", "Inicio", "Fin" });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_UsuarioInternoId",
                table: "ActividadUsuarios",
                column: "UsuarioInternoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisId",
                table: "Ciudades",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_EmpresaId",
                table: "Contactos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_RolContactoId",
                table: "Contactos",
                column: "RolContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CiudadId",
                table: "Empresas",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EstadoId",
                table: "Empresas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Nit",
                table: "Empresas",
                column: "Nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_PaisId",
                table: "Empresas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SectorId",
                table: "Empresas",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_Nombre",
                table: "EstadoActividad",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Nombre",
                table: "Estados",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCambiosOportunidad_OportunidadId",
                table: "HistorialCambiosOportunidad",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_ContactoPrincipalId",
                table: "Oportunidades",
                column: "ContactoPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_EmpresaId",
                table: "Oportunidades",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefijosTelefonicos_PaisId",
                table: "PrefijosTelefonicos",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_OportunidadId",
                table: "Propuestas",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectores_Nombre",
                table: "Sectores",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividad_Nombre",
                table: "TipoActividad",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_Activo",
                table: "UsuarioInterno",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_Email",
                table: "UsuarioInterno",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadUsuarios");

            migrationBuilder.DropTable(
                name: "HistorialCambiosOportunidad");

            migrationBuilder.DropTable(
                name: "PrefijosTelefonicos");

            migrationBuilder.DropTable(
                name: "Propuestas");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "EstadoActividad");

            migrationBuilder.DropTable(
                name: "Oportunidades");

            migrationBuilder.DropTable(
                name: "TipoActividad");

            migrationBuilder.DropTable(
                name: "UsuarioInterno");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "RolesContacto");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
