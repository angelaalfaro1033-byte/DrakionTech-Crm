using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoActividadId = table.Column<int>(type: "int", nullable: false),
                    EstadoActividadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resultado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ExternalCalendarEventId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    ContactoId = table.Column<int>(type: "int", nullable: true),
                    OportunidadId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ActividadPreviaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioInternoId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Actividades_ActividadPreviaId",
                        column: x => x.ActividadPreviaId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadUsuarios",
                columns: table => new
                {
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EsResponsable = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioInternoId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadUsuarios", x => new { x.ActividadId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_ActividadUsuarios_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosPublicacionMarketing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
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
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolContactoId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    FechaVinculacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEspecial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TemplateHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

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
                    PorcentajeDedicacion = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 100m),
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
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoSalarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoSalarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpleadoSalarios_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaCorreos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaCorreos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrefijoTelefonicoId = table.Column<int>(type: "int", nullable: true),
                    PrefijoTelefonicoCodigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RepresentanteLegal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacionEmpresa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRegistroCrm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tamaño = table.Column<int>(type: "int", nullable: true),
                    SectorEmpresaId = table.Column<int>(type: "int", nullable: true),
                    SubsectorEmpresaId = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Seguimiento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    HaTrabajadoAntes = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleEventoArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleEventoId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleFileId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleEventoArchivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleEventId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    EmpresaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaNit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sincronizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaImportacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedGoogle = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleEventos", x => x.Id);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCambiosOportunidad", x => x.Id);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "HistorialesEtapaProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    EtapaAnterior = table.Column<int>(type: "int", nullable: false),
                    EtapaNueva = table.Column<int>(type: "int", nullable: false),
                    PorcentajeIva = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorCalculado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesEtapaProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetricasPublicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionMarketingId = table.Column<int>(type: "int", nullable: false),
                    RedSocial = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visualizaciones = table.Column<int>(type: "int", nullable: false),
                    Reacciones = table.Column<int>(type: "int", nullable: false),
                    Alcance = table.Column<int>(type: "int", nullable: false),
                    ContactoAreaComercial = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricasPublicacion", x => x.Id);
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
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    FechaUltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIso = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrefijosTelefonicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresupuestoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EtapaFlujo = table.Column<int>(type: "int", nullable: false),
                    SupervisorInternoId = table.Column<int>(type: "int", nullable: true),
                    SupervisorExternoId = table.Column<int>(type: "int", nullable: true),
                    EquipoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentosUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FasesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false),
                    OportunidadId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Contactos_SupervisorExternoId",
                        column: x => x.SupervisorExternoId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesMarketing", x => x.Id);
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
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "RolesContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesContacto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ActivationTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolesUsuario_RolId",
                        column: x => x.RolId,
                        principalTable: "RolesUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectores_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sectores_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectoresEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectoresEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectoresEmpresa_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectoresEmpresa_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubsectoresEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsectoresEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubsectoresEmpresa_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubsectoresEmpresa_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoActividad_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoActividad_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioInterno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioInterno_Usuarios_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioInterno_Usuarios_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "EmailTemplates",
                columns: new[] { "Id", "Activo", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre", "TemplateHtml" },
                values: new object[] { 1, true, null, null, null, null, "ActivacionCuenta", "\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <meta charset='utf-8' />\r\n  <meta name='viewport' content='width=device-width, initial-scale=1.0' />\r\n</head>\r\n<body style='margin:0;padding:0;background-color:#f5f4f0;font-family:Arial,sans-serif;'>\r\n  <table width='100%' cellpadding='0' cellspacing='0' style='background-color:#f5f4f0;padding:40px 0;'>\r\n    <tr>\r\n      <td align='center'>\r\n        <table width='560' cellpadding='0' cellspacing='0' style='background-color:#ffffff;border-radius:20px;border:1px solid #e8e6e0;overflow:hidden;'>\r\n          <!-- HEADER -->\r\n          <tr>\r\n            <td style='background-color:#111827;padding:32px 40px;text-align:center;'>\r\n              <p style='margin:0;font-size:22px;font-weight:700;color:#ffffff;letter-spacing:-0.5px;'>DrakionTech CRM</p>\r\n              <p style='margin:6px 0 0;font-size:13px;color:#9ca3af;'>Plataforma de gestión comercial</p>\r\n            </td>\r\n          </tr>\r\n          <!-- ÍCONO -->\r\n          <tr>\r\n            <td align='center' style='padding:36px 40px 0;'>\r\n              <div style='width:64px;height:64px;background-color:#f3f4f6;border-radius:16px;display:inline-block;text-align:center;line-height:64px;'>\r\n                <span style='font-size:28px;color:#374151;font-weight:700;'>&#128274;</span>\r\n              </div>\r\n            </td>\r\n          </tr>\r\n          <!-- CONTENIDO -->\r\n          <tr>\r\n            <td style='padding:24px 40px 16px;text-align:center;'>\r\n              <h1 style='margin:0 0 10px;font-size:24px;font-weight:700;color:#111827;letter-spacing:-0.4px;'>Hola, {{Nombre}}</h1>\r\n              <p style='margin:0;font-size:15px;color:#6b7280;line-height:1.7;'>\r\n                Tu cuenta en DrakionTech CRM ha sido creada.<br/>\r\n                Haz clic en el botón para activarla y comenzar.\r\n              </p>\r\n            </td>\r\n          </tr>\r\n          <!-- BOTÓN -->\r\n          <tr>\r\n            <td align='center' style='padding:28px 40px;'>\r\n              <a href='{{ActivationLink}}'\r\n                 style='display:inline-block;background-color:#111827;color:#ffffff;text-decoration:none;font-size:15px;font-weight:600;padding:14px 36px;border-radius:12px;letter-spacing:0.01em;'>\r\n                Activar mi cuenta &rarr;\r\n              </a>\r\n            </td>\r\n          </tr>\r\n          <!-- AVISO ENLACE -->\r\n          <tr>\r\n            <td style='padding:0 40px 24px;text-align:center;'>\r\n              <p style='margin:0;font-size:12px;color:#9ca3af;line-height:1.6;'>\r\n                Si el bot&oacute;n no funciona, copia y pega este enlace en tu navegador:<br/>\r\n                <span style='color:#2563eb;word-break:break-all;'>{{ActivationLink}}</span>\r\n              </p>\r\n            </td>\r\n          </tr>\r\n          <!-- DIVIDER -->\r\n          <tr>\r\n            <td style='padding:0 40px;'>\r\n              <div style='height:1px;background-color:#f3f4f6;'></div>\r\n            </td>\r\n          </tr>\r\n          <!-- FOOTER -->\r\n          <tr>\r\n            <td style='padding:24px 40px;text-align:center;'>\r\n              <p style='margin:0;font-size:12px;color:#9ca3af;line-height:1.6;'>\r\n                Este correo fue enviado autom&aacute;ticamente por DrakionTech CRM.<br/>\r\n                Si no solicitaste esto, puedes ignorar este mensaje.\r\n              </p>\r\n            </td>\r\n          </tr>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </table>\r\n</body>\r\n</html>\r\n" });

            migrationBuilder.InsertData(
                table: "EstadoActividad",
                columns: new[] { "Id", "Activo", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, true, null, null, null, null, "Programada" },
                    { 2, true, null, null, null, null, "Completada" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Lead" },
                    { 2, null, null, null, null, "Prospecto" },
                    { 3, null, null, null, null, "Cliente" },
                    { 4, null, null, null, null, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "CodigoIso", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, "CO", null, null, null, null, "Colombia" },
                    { 2, "AR", null, null, null, null, "Argentina" },
                    { 3, "BO", null, null, null, null, "Bolivia" },
                    { 4, "BR", null, null, null, null, "Brasil" },
                    { 5, "CL", null, null, null, null, "Chile" },
                    { 6, "EC", null, null, null, null, "Ecuador" },
                    { 7, "GY", null, null, null, null, "Guyana" },
                    { 8, "PY", null, null, null, null, "Paraguay" },
                    { 9, "PE", null, null, null, null, "Perú" },
                    { 10, "SR", null, null, null, null, "Surinam" },
                    { 11, "UY", null, null, null, null, "Uruguay" },
                    { 12, "VE", null, null, null, null, "Venezuela" },
                    { 13, "MX", null, null, null, null, "México" },
                    { 14, "US", null, null, null, null, "Estados Unidos" },
                    { 15, "CA", null, null, null, null, "Canadá" }
                });

            migrationBuilder.InsertData(
                table: "RolesContacto",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Desconocido" },
                    { 2, null, null, null, null, "CEO" },
                    { 3, null, null, null, null, "CTO" },
                    { 4, null, null, null, null, "CFO" },
                    { 5, null, null, null, null, "COO" },
                    { 6, null, null, null, null, "Director" },
                    { 7, null, null, null, null, "Gerente" },
                    { 8, null, null, null, null, "Project Manager" },
                    { 9, null, null, null, null, "Líder Técnico" },
                    { 10, null, null, null, null, "Recursos Humanos" },
                    { 11, null, null, null, null, "Compras" },
                    { 12, null, null, null, null, "Ventas" },
                    { 13, null, null, null, null, "Marketing" },
                    { 14, null, null, null, null, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "RolesUsuario",
                columns: new[] { "Id", "Activo", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, true, null, null, null, null, "Administrador" },
                    { 2, true, null, null, null, null, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Salud" },
                    { 2, null, null, null, null, "Educación" },
                    { 3, null, null, null, null, "Retail Comercio" },
                    { 4, null, null, null, null, "Logística y Transporte" },
                    { 5, null, null, null, null, "Inmobiliario" },
                    { 6, null, null, null, null, "Finanzas" },
                    { 7, null, null, null, null, "Manufactura" },
                    { 8, null, null, null, null, "Servicios Profesionales" },
                    { 9, null, null, null, null, "Gobierno / Sector Público" },
                    { 10, null, null, null, null, "Construcción" },
                    { 11, null, null, null, null, "Turismo y Hospitalidad" },
                    { 12, null, null, null, null, "Agricultura / Agroindustria" },
                    { 13, null, null, null, null, "Energía" },
                    { 14, null, null, null, null, "Tecnología" }
                });

            migrationBuilder.InsertData(
                table: "SectoresEmpresa",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Primario" },
                    { 2, null, null, null, null, "Manufactura" },
                    { 3, null, null, null, null, "Comercio" },
                    { 4, null, null, null, null, "Servicios" }
                });

            migrationBuilder.InsertData(
                table: "TipoActividad",
                columns: new[] { "Id", "Activo", "CreatedAt", "CreatedByUserId", "Descripcion", "ModifiedAt", "ModifiedByUserId", "Nombre" },
                values: new object[,]
                {
                    { 1, true, null, null, "Llamada telefónica con el cliente", null, null, "Llamada" },
                    { 2, true, null, null, "Reunión presencial o virtual", null, null, "Reunión" },
                    { 3, true, null, null, "Envío o seguimiento vía correo electrónico", null, null, "Correo" },
                    { 4, true, null, null, "Seguimiento comercial", null, null, "Seguimiento" },
                    { 5, true, null, null, "Demostración de producto o servicio", null, null, "Demo" }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Bogotá", 1 },
                    { 2, null, null, null, null, "Medellín", 1 },
                    { 3, null, null, null, null, "Cali", 1 },
                    { 4, null, null, null, null, "Barranquilla", 1 },
                    { 5, null, null, null, null, "Cartagena", 1 },
                    { 6, null, null, null, null, "Bucaramanga", 1 },
                    { 7, null, null, null, null, "Cúcuta", 1 },
                    { 8, null, null, null, null, "Pereira", 1 },
                    { 9, null, null, null, null, "Manizales", 1 },
                    { 10, null, null, null, null, "Armenia", 1 },
                    { 11, null, null, null, null, "Ibagué", 1 },
                    { 12, null, null, null, null, "Neiva", 1 },
                    { 13, null, null, null, null, "Villavicencio", 1 },
                    { 14, null, null, null, null, "Pasto", 1 },
                    { 15, null, null, null, null, "Popayán", 1 },
                    { 16, null, null, null, null, "Santa Marta", 1 },
                    { 17, null, null, null, null, "Valledupar", 1 },
                    { 18, null, null, null, null, "Montería", 1 },
                    { 19, null, null, null, null, "Sincelejo", 1 },
                    { 20, null, null, null, null, "Riohacha", 1 },
                    { 21, null, null, null, null, "Yopal", 1 },
                    { 22, null, null, null, null, "Tunja", 1 },
                    { 23, null, null, null, null, "Florencia", 1 },
                    { 24, null, null, null, null, "Mocoa", 1 },
                    { 25, null, null, null, null, "San José del Guaviare", 1 },
                    { 26, null, null, null, null, "Leticia", 1 },
                    { 27, null, null, null, null, "Mitú", 1 },
                    { 28, null, null, null, null, "Puerto Carreño", 1 },
                    { 29, null, null, null, null, "Quibdó", 1 },
                    { 30, null, null, null, null, "Arauca", 1 },
                    { 31, null, null, null, null, "San Andrés", 1 },
                    { 32, null, null, null, null, "Inírida", 1 },
                    { 33, null, null, null, null, "Buenaventura", 1 },
                    { 34, null, null, null, null, "Buenos Aires", 2 },
                    { 35, null, null, null, null, "Córdoba", 2 },
                    { 36, null, null, null, null, "São Paulo", 4 },
                    { 37, null, null, null, null, "Rio de Janeiro", 4 },
                    { 38, null, null, null, null, "Santiago", 5 },
                    { 39, null, null, null, null, "Lima", 9 },
                    { 40, null, null, null, null, "Ciudad de México", 13 },
                    { 41, null, null, null, null, "Monterrey", 13 },
                    { 42, null, null, null, null, "New York", 14 },
                    { 43, null, null, null, null, "Los Ángeles", 14 },
                    { 46, null, null, null, null, "La Paz", 3 },
                    { 47, null, null, null, null, "Quito", 6 },
                    { 48, null, null, null, null, "Georgetown", 7 },
                    { 49, null, null, null, null, "Asunción", 8 },
                    { 50, null, null, null, null, "Paramaribo", 10 },
                    { 51, null, null, null, null, "Montevideo", 11 },
                    { 52, null, null, null, null, "Caracas", 12 }
                });

            migrationBuilder.InsertData(
                table: "PrefijosTelefonicos",
                columns: new[] { "Id", "Codigo", "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "+57", null, null, null, null, "Colombia", 1 },
                    { 2, "+1", null, null, null, null, "Estados Unidos", 14 },
                    { 3, "+54", null, null, null, null, "Argentina", 2 },
                    { 4, "+591", null, null, null, null, "Bolivia", 3 },
                    { 5, "+55", null, null, null, null, "Brasil", 4 },
                    { 6, "+56", null, null, null, null, "Chile", 5 },
                    { 7, "+593", null, null, null, null, "Ecuador", 6 },
                    { 8, "+592", null, null, null, null, "Guyana", 7 },
                    { 9, "+595", null, null, null, null, "Paraguay", 8 },
                    { 10, "+51", null, null, null, null, "Perú", 9 },
                    { 11, "+597", null, null, null, null, "Surinam", 10 },
                    { 12, "+598", null, null, null, null, "Uruguay", 11 },
                    { 13, "+58", null, null, null, null, "Venezuela", 12 },
                    { 14, "+52", null, null, null, null, "México", 13 },
                    { 15, "+1", null, null, null, null, "Canadá", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ActividadPreviaId",
                table: "Actividades",
                column: "ActividadPreviaId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ContactoId",
                table: "Actividades",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_CreatedByUserId",
                table: "Actividades",
                column: "CreatedByUserId");

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
                name: "IX_Actividades_ModifiedByUserId",
                table: "Actividades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_OportunidadId",
                table: "Actividades",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TipoActividadId",
                table: "Actividades",
                column: "TipoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioId",
                table: "Actividades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioId_Inicio_Fin",
                table: "Actividades",
                columns: new[] { "UsuarioId", "Inicio", "Fin" });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioInternoId",
                table: "Actividades",
                column: "UsuarioInternoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_CreatedByUserId",
                table: "ActividadUsuarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_ModifiedByUserId",
                table: "ActividadUsuarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_UsuarioId",
                table: "ActividadUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_UsuarioInternoId",
                table: "ActividadUsuarios",
                column: "UsuarioInternoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_CreatedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_ModifiedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_PublicacionMarketingId",
                table: "ArchivosPublicacionMarketing",
                column: "PublicacionMarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CreatedByUserId",
                table: "Areas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ModifiedByUserId",
                table: "Areas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ResponsableId",
                table: "Areas",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_CreatedByUserId",
                table: "Ciudades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ModifiedByUserId",
                table: "Ciudades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisId",
                table: "Ciudades",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_CreatedByUserId",
                table: "Contactos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_EmpresaId",
                table: "Contactos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ModifiedByUserId",
                table: "Contactos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_RolContactoId",
                table: "Contactos",
                column: "RolContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_CreatedByUserId",
                table: "EmailTemplates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_ModifiedByUserId",
                table: "EmailTemplates",
                column: "ModifiedByUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CreatedByUserId",
                table: "Empleados",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Email",
                table: "Empleados",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EspecialidadId",
                table: "Empleados",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ModifiedByUserId",
                table: "Empleados",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_NumeroDocumento",
                table: "Empleados",
                column: "NumeroDocumento",
                unique: true,
                filter: "[NumeroDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolUsuarioId",
                table: "Empleados",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoSalarios_CreatedByUserId",
                table: "EmpleadoSalarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoSalarios_EmpleadoId",
                table: "EmpleadoSalarios",
                column: "EmpleadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoSalarios_ModifiedByUserId",
                table: "EmpleadoSalarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_CreatedByUserId",
                table: "EmpresaCorreos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_EmpresaId",
                table: "EmpresaCorreos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_ModifiedByUserId",
                table: "EmpresaCorreos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CiudadId",
                table: "Empresas",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CreatedByUserId",
                table: "Empresas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ModifiedByUserId",
                table: "Empresas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_PaisId",
                table: "Empresas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SectorEmpresaId",
                table: "Empresas",
                column: "SectorEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SubsectorEmpresaId",
                table: "Empresas",
                column: "SubsectorEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_CreatedByUserId",
                table: "Especialidades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_ModifiedByUserId",
                table: "Especialidades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_RolUsuarioId",
                table: "Especialidades",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_CreatedByUserId",
                table: "EstadoActividad",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_ModifiedByUserId",
                table: "EstadoActividad",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_Nombre",
                table: "EstadoActividad",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_CreatedByUserId",
                table: "Estados",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ModifiedByUserId",
                table: "Estados",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Nombre",
                table: "Estados",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventoArchivos_CreatedByUserId",
                table: "GoogleEventoArchivos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventoArchivos_GoogleEventoId",
                table: "GoogleEventoArchivos",
                column: "GoogleEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventoArchivos_ModifiedByUserId",
                table: "GoogleEventoArchivos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventos_CreatedByUserId",
                table: "GoogleEventos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventos_GoogleEventId",
                table: "GoogleEventos",
                column: "GoogleEventId",
                unique: true,
                filter: "[GoogleEventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventos_ModifiedByUserId",
                table: "GoogleEventos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCambiosOportunidad_CreatedByUserId",
                table: "HistorialCambiosOportunidad",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCambiosOportunidad_ModifiedByUserId",
                table: "HistorialCambiosOportunidad",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCambiosOportunidad_OportunidadId",
                table: "HistorialCambiosOportunidad",
                column: "OportunidadId");

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

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEtapaProyecto_CreatedByUserId",
                table: "HistorialesEtapaProyecto",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEtapaProyecto_ModifiedByUserId",
                table: "HistorialesEtapaProyecto",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEtapaProyecto_ProyectoId",
                table: "HistorialesEtapaProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_CreatedByUserId",
                table: "MetricasPublicacion",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_ModifiedByUserId",
                table: "MetricasPublicacion",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_PublicacionMarketingId",
                table: "MetricasPublicacion",
                column: "PublicacionMarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_ContactoPrincipalId",
                table: "Oportunidades",
                column: "ContactoPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_CreatedByUserId",
                table: "Oportunidades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_EmpresaId",
                table: "Oportunidades",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_ModifiedByUserId",
                table: "Oportunidades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosProyecto_CreatedByUserId",
                table: "PagosProyecto",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosProyecto_ModifiedByUserId",
                table: "PagosProyecto",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosProyecto_ProyectoId",
                table: "PagosProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_CreatedByUserId",
                table: "Paises",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ModifiedByUserId",
                table: "Paises",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefijosTelefonicos_CreatedByUserId",
                table: "PrefijosTelefonicos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefijosTelefonicos_ModifiedByUserId",
                table: "PrefijosTelefonicos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefijosTelefonicos_PaisId",
                table: "PrefijosTelefonicos",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_CreatedByUserId",
                table: "Propuestas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_ModifiedByUserId",
                table: "Propuestas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_OportunidadId",
                table: "Propuestas",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AreaId",
                table: "Proyectos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_CreatedByUserId",
                table: "Proyectos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ModifiedByUserId",
                table: "Proyectos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_OportunidadId",
                table: "Proyectos",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ResponsableId",
                table: "Proyectos",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_SupervisorExternoId",
                table: "Proyectos",
                column: "SupervisorExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_SupervisorInternoId",
                table: "Proyectos",
                column: "SupervisorInternoId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_CreatedByUserId",
                table: "PublicacionesMarketing",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_ModifiedByUserId",
                table: "PublicacionesMarketing",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_ResponsableId",
                table: "PublicacionesMarketing",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_CreatedByUserId",
                table: "PublicacionRedesSociales",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_ModifiedByUserId",
                table: "PublicacionRedesSociales",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_PublicacionMarketingId_RedSocial",
                table: "PublicacionRedesSociales",
                columns: new[] { "PublicacionMarketingId", "RedSocial" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesContacto_CreatedByUserId",
                table: "RolesContacto",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesContacto_ModifiedByUserId",
                table: "RolesContacto",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuario_CreatedByUserId",
                table: "RolesUsuario",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuario_ModifiedByUserId",
                table: "RolesUsuario",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectores_CreatedByUserId",
                table: "Sectores",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectores_ModifiedByUserId",
                table: "Sectores",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectores_Nombre",
                table: "Sectores",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectoresEmpresa_CreatedByUserId",
                table: "SectoresEmpresa",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectoresEmpresa_ModifiedByUserId",
                table: "SectoresEmpresa",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSubsector_SubsectoresId",
                table: "SectorSubsector",
                column: "SubsectoresId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsectoresEmpresa_CreatedByUserId",
                table: "SubsectoresEmpresa",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsectoresEmpresa_ModifiedByUserId",
                table: "SubsectoresEmpresa",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividad_CreatedByUserId",
                table: "TipoActividad",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividad_ModifiedByUserId",
                table: "TipoActividad",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividad_Nombre",
                table: "TipoActividad",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_Activo",
                table: "UsuarioInterno",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_CreatedByUserId",
                table: "UsuarioInterno",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_Email",
                table: "UsuarioInterno",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_ModifiedByUserId",
                table: "UsuarioInterno",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AreaId",
                table: "Usuarios",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CreatedByUserId",
                table: "Usuarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ModifiedByUserId",
                table: "Usuarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Contactos_ContactoId",
                table: "Actividades",
                column: "ContactoId",
                principalTable: "Contactos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Empresas_EmpresaId",
                table: "Actividades",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_EstadoActividad_EstadoActividadId",
                table: "Actividades",
                column: "EstadoActividadId",
                principalTable: "EstadoActividad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Oportunidades_OportunidadId",
                table: "Actividades",
                column: "OportunidadId",
                principalTable: "Oportunidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_TipoActividad_TipoActividadId",
                table: "Actividades",
                column: "TipoActividadId",
                principalTable: "TipoActividad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_UsuarioInterno_UsuarioInternoId",
                table: "Actividades",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Usuarios_CreatedByUserId",
                table: "Actividades",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Usuarios_ModifiedByUserId",
                table: "Actividades",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ActividadUsuarios_Usuarios_CreatedByUserId",
                table: "ActividadUsuarios",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_ModifiedByUserId",
                table: "ActividadUsuarios",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_UsuarioId",
                table: "ActividadUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivosPublicacionMarketing_PublicacionesMarketing_PublicacionMarketingId",
                table: "ArchivosPublicacionMarketing",
                column: "PublicacionMarketingId",
                principalTable: "PublicacionesMarketing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivosPublicacionMarketing_Usuarios_CreatedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivosPublicacionMarketing_Usuarios_ModifiedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Usuarios_CreatedByUserId",
                table: "Areas",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Usuarios_ModifiedByUserId",
                table: "Areas",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Usuarios_ResponsableId",
                table: "Areas",
                column: "ResponsableId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Paises_PaisId",
                table: "Ciudades",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Usuarios_CreatedByUserId",
                table: "Ciudades",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Usuarios_ModifiedByUserId",
                table: "Ciudades",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Empresas_EmpresaId",
                table: "Contactos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_RolesContacto_RolContactoId",
                table: "Contactos",
                column: "RolContactoId",
                principalTable: "RolesContacto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuarios_CreatedByUserId",
                table: "Contactos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuarios_ModifiedByUserId",
                table: "Contactos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplates_Usuarios_CreatedByUserId",
                table: "EmailTemplates",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplates_Usuarios_ModifiedByUserId",
                table: "EmailTemplates",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoProyectoAsignaciones_Empleados_EmpleadoId",
                table: "EmpleadoProyectoAsignaciones",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoProyectoAsignaciones_Proyectos_ProyectoId",
                table: "EmpleadoProyectoAsignaciones",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoProyectoAsignaciones_Usuarios_CreatedByUserId",
                table: "EmpleadoProyectoAsignaciones",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoProyectoAsignaciones_Usuarios_ModifiedByUserId",
                table: "EmpleadoProyectoAsignaciones",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Especialidades_EspecialidadId",
                table: "Empleados",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_RolesUsuario_RolUsuarioId",
                table: "Empleados",
                column: "RolUsuarioId",
                principalTable: "RolesUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Usuarios_CreatedByUserId",
                table: "Empleados",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Usuarios_ModifiedByUserId",
                table: "Empleados",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoSalarios_Usuarios_CreatedByUserId",
                table: "EmpleadoSalarios",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoSalarios_Usuarios_ModifiedByUserId",
                table: "EmpleadoSalarios",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaCorreos_Empresas_EmpresaId",
                table: "EmpresaCorreos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaCorreos_Usuarios_CreatedByUserId",
                table: "EmpresaCorreos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaCorreos_Usuarios_ModifiedByUserId",
                table: "EmpresaCorreos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Paises_PaisId",
                table: "Empresas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Usuarios_CreatedByUserId",
                table: "Empresas",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Usuarios_ModifiedByUserId",
                table: "Empresas",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_RolesUsuario_RolUsuarioId",
                table: "Especialidades",
                column: "RolUsuarioId",
                principalTable: "RolesUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_Usuarios_CreatedByUserId",
                table: "Especialidades",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_Usuarios_ModifiedByUserId",
                table: "Especialidades",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoActividad_Usuarios_CreatedByUserId",
                table: "EstadoActividad",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoActividad_Usuarios_ModifiedByUserId",
                table: "EstadoActividad",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Usuarios_CreatedByUserId",
                table: "Estados",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Usuarios_ModifiedByUserId",
                table: "Estados",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleEventoArchivos_GoogleEventos_GoogleEventoId",
                table: "GoogleEventoArchivos",
                column: "GoogleEventoId",
                principalTable: "GoogleEventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleEventoArchivos_Usuarios_CreatedByUserId",
                table: "GoogleEventoArchivos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleEventoArchivos_Usuarios_ModifiedByUserId",
                table: "GoogleEventoArchivos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleEventos_Usuarios_CreatedByUserId",
                table: "GoogleEventos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleEventos_Usuarios_ModifiedByUserId",
                table: "GoogleEventos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialCambiosOportunidad_Oportunidades_OportunidadId",
                table: "HistorialCambiosOportunidad",
                column: "OportunidadId",
                principalTable: "Oportunidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialCambiosOportunidad_Usuarios_CreatedByUserId",
                table: "HistorialCambiosOportunidad",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialCambiosOportunidad_Usuarios_ModifiedByUserId",
                table: "HistorialCambiosOportunidad",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialEmpresas_Usuarios_UsuarioResponsableId",
                table: "HistorialEmpresas",
                column: "UsuarioResponsableId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEtapaProyecto_Proyectos_ProyectoId",
                table: "HistorialesEtapaProyecto",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEtapaProyecto_Usuarios_CreatedByUserId",
                table: "HistorialesEtapaProyecto",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEtapaProyecto_Usuarios_ModifiedByUserId",
                table: "HistorialesEtapaProyecto",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetricasPublicacion_PublicacionesMarketing_PublicacionMarketingId",
                table: "MetricasPublicacion",
                column: "PublicacionMarketingId",
                principalTable: "PublicacionesMarketing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MetricasPublicacion_Usuarios_CreatedByUserId",
                table: "MetricasPublicacion",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetricasPublicacion_Usuarios_ModifiedByUserId",
                table: "MetricasPublicacion",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Oportunidades_Usuarios_CreatedByUserId",
                table: "Oportunidades",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Oportunidades_Usuarios_ModifiedByUserId",
                table: "Oportunidades",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosProyecto_Proyectos_ProyectoId",
                table: "PagosProyecto",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosProyecto_Usuarios_CreatedByUserId",
                table: "PagosProyecto",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosProyecto_Usuarios_ModifiedByUserId",
                table: "PagosProyecto",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Usuarios_CreatedByUserId",
                table: "Paises",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Usuarios_ModifiedByUserId",
                table: "Paises",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrefijosTelefonicos_Usuarios_CreatedByUserId",
                table: "PrefijosTelefonicos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrefijosTelefonicos_Usuarios_ModifiedByUserId",
                table: "PrefijosTelefonicos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propuestas_Usuarios_CreatedByUserId",
                table: "Propuestas",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propuestas_Usuarios_ModifiedByUserId",
                table: "Propuestas",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_CreatedByUserId",
                table: "Proyectos",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_ModifiedByUserId",
                table: "Proyectos",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_ResponsableId",
                table: "Proyectos",
                column: "ResponsableId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Usuarios_SupervisorInternoId",
                table: "Proyectos",
                column: "SupervisorInternoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionesMarketing_Usuarios_CreatedByUserId",
                table: "PublicacionesMarketing",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionesMarketing_Usuarios_ModifiedByUserId",
                table: "PublicacionesMarketing",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionesMarketing_Usuarios_ResponsableId",
                table: "PublicacionesMarketing",
                column: "ResponsableId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionRedesSociales_Usuarios_CreatedByUserId",
                table: "PublicacionRedesSociales",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionRedesSociales_Usuarios_ModifiedByUserId",
                table: "PublicacionRedesSociales",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesContacto_Usuarios_CreatedByUserId",
                table: "RolesContacto",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesContacto_Usuarios_ModifiedByUserId",
                table: "RolesContacto",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesUsuario_Usuarios_CreatedByUserId",
                table: "RolesUsuario",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesUsuario_Usuarios_ModifiedByUserId",
                table: "RolesUsuario",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Usuarios_CreatedByUserId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Usuarios_ModifiedByUserId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Usuarios_ResponsableId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesUsuario_Usuarios_CreatedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesUsuario_Usuarios_ModifiedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropTable(
                name: "ActividadUsuarios");

            migrationBuilder.DropTable(
                name: "ArchivosPublicacionMarketing");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "EmpleadoProyectoAsignaciones");

            migrationBuilder.DropTable(
                name: "EmpleadoSalarios");

            migrationBuilder.DropTable(
                name: "EmpresaCorreos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "GoogleEventoArchivos");

            migrationBuilder.DropTable(
                name: "HistorialCambiosOportunidad");

            migrationBuilder.DropTable(
                name: "HistorialEmpresas");

            migrationBuilder.DropTable(
                name: "HistorialesEtapaProyecto");

            migrationBuilder.DropTable(
                name: "MetricasPublicacion");

            migrationBuilder.DropTable(
                name: "PagosProyecto");

            migrationBuilder.DropTable(
                name: "PrefijosTelefonicos");

            migrationBuilder.DropTable(
                name: "Propuestas");

            migrationBuilder.DropTable(
                name: "PublicacionRedesSociales");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "SectorSubsector");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "GoogleEventos");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "PublicacionesMarketing");

            migrationBuilder.DropTable(
                name: "EstadoActividad");

            migrationBuilder.DropTable(
                name: "TipoActividad");

            migrationBuilder.DropTable(
                name: "UsuarioInterno");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Oportunidades");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "RolesContacto");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "SectoresEmpresa");

            migrationBuilder.DropTable(
                name: "SubsectoresEmpresa");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "RolesUsuario");
        }
    }
}
