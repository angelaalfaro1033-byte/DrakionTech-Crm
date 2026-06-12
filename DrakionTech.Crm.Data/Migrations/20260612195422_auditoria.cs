using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class auditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UsuarioInterno",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "UsuarioInterno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "UsuarioInterno",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "UsuarioInterno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TipoActividad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "TipoActividad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "TipoActividad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "TipoActividad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SubsectoresEmpresa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "SubsectoresEmpresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SubsectoresEmpresa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "SubsectoresEmpresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SectoresEmpresa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "SectoresEmpresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SectoresEmpresa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "SectoresEmpresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sectores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Sectores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Sectores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Sectores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RolesUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "RolesUsuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "RolesUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "RolesUsuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RolesContacto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "RolesContacto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "RolesContacto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "RolesContacto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PublicacionRedesSociales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "PublicacionRedesSociales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "PublicacionRedesSociales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "PublicacionRedesSociales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PublicacionesMarketing",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "PublicacionesMarketing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "PublicacionesMarketing",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "PublicacionesMarketing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Propuestas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Propuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Propuestas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Propuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PrefijosTelefonicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "PrefijosTelefonicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "PrefijosTelefonicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "PrefijosTelefonicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Paises",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Paises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Paises",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Paises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PagosProyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "PagosProyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "PagosProyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "PagosProyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Oportunidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Oportunidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Oportunidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Oportunidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MetricasPublicacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "MetricasPublicacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "MetricasPublicacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "MetricasPublicacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HistorialesEtapaProyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "HistorialesEtapaProyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HistorialesEtapaProyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "HistorialesEtapaProyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HistorialCambiosOportunidad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "HistorialCambiosOportunidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HistorialCambiosOportunidad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "HistorialCambiosOportunidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GoogleEventos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "GoogleEventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GoogleEventos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "GoogleEventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GoogleEventoArchivos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "GoogleEventoArchivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GoogleEventoArchivos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "GoogleEventoArchivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Estados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Estados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EstadoActividad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "EstadoActividad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EstadoActividad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "EstadoActividad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Especialidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Especialidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Especialidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Especialidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Empresas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Empresas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmpresaCorreos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "EmpresaCorreos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EmpresaCorreos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "EmpresaCorreos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmpleadoSalarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "EmpleadoSalarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EmpleadoSalarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "EmpleadoSalarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Empleados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Empleados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "EmailTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "EmailTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Contactos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Contactos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Contactos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Contactos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ciudades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Ciudades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ArchivosPublicacionMarketing",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ArchivosPublicacionMarketing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ArchivosPublicacionMarketing",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "ArchivosPublicacionMarketing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ActividadUsuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ActividadUsuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ActividadUsuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "ActividadUsuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Actividades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Actividades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Actividades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Actividades",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "EstadoActividad",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "EstadoActividad",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesContacto",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectoresEmpresa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectoresEmpresa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectoresEmpresa",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectoresEmpresa",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TipoActividad",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TipoActividad",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TipoActividad",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TipoActividad",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TipoActividad",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CreatedByUserId",
                table: "Usuarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ModifiedByUserId",
                table: "Usuarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_CreatedByUserId",
                table: "UsuarioInterno",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInterno_ModifiedByUserId",
                table: "UsuarioInterno",
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
                name: "IX_SubsectoresEmpresa_CreatedByUserId",
                table: "SubsectoresEmpresa",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsectoresEmpresa_ModifiedByUserId",
                table: "SubsectoresEmpresa",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectoresEmpresa_CreatedByUserId",
                table: "SectoresEmpresa",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectoresEmpresa_ModifiedByUserId",
                table: "SectoresEmpresa",
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
                name: "IX_RolesUsuario_CreatedByUserId",
                table: "RolesUsuario",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuario_ModifiedByUserId",
                table: "RolesUsuario",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesContacto_CreatedByUserId",
                table: "RolesContacto",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesContacto_ModifiedByUserId",
                table: "RolesContacto",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_CreatedByUserId",
                table: "PublicacionRedesSociales",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionRedesSociales_ModifiedByUserId",
                table: "PublicacionRedesSociales",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_CreatedByUserId",
                table: "PublicacionesMarketing",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesMarketing_ModifiedByUserId",
                table: "PublicacionesMarketing",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_CreatedByUserId",
                table: "Proyectos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ModifiedByUserId",
                table: "Proyectos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_CreatedByUserId",
                table: "Propuestas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_ModifiedByUserId",
                table: "Propuestas",
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
                name: "IX_Paises_CreatedByUserId",
                table: "Paises",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ModifiedByUserId",
                table: "Paises",
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
                name: "IX_Oportunidades_CreatedByUserId",
                table: "Oportunidades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_ModifiedByUserId",
                table: "Oportunidades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_CreatedByUserId",
                table: "MetricasPublicacion",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricasPublicacion_ModifiedByUserId",
                table: "MetricasPublicacion",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEtapaProyecto_CreatedByUserId",
                table: "HistorialesEtapaProyecto",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEtapaProyecto_ModifiedByUserId",
                table: "HistorialesEtapaProyecto",
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
                name: "IX_GoogleEventos_CreatedByUserId",
                table: "GoogleEventos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventos_ModifiedByUserId",
                table: "GoogleEventos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventoArchivos_CreatedByUserId",
                table: "GoogleEventoArchivos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEventoArchivos_ModifiedByUserId",
                table: "GoogleEventoArchivos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_CreatedByUserId",
                table: "Estados",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ModifiedByUserId",
                table: "Estados",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_CreatedByUserId",
                table: "EstadoActividad",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoActividad_ModifiedByUserId",
                table: "EstadoActividad",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_CreatedByUserId",
                table: "Especialidades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_ModifiedByUserId",
                table: "Especialidades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CreatedByUserId",
                table: "Empresas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ModifiedByUserId",
                table: "Empresas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_CreatedByUserId",
                table: "EmpresaCorreos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCorreos_ModifiedByUserId",
                table: "EmpresaCorreos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoSalarios_CreatedByUserId",
                table: "EmpleadoSalarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoSalarios_ModifiedByUserId",
                table: "EmpleadoSalarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CreatedByUserId",
                table: "Empleados",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ModifiedByUserId",
                table: "Empleados",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_CreatedByUserId",
                table: "EmailTemplates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_ModifiedByUserId",
                table: "EmailTemplates",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_CreatedByUserId",
                table: "Contactos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ModifiedByUserId",
                table: "Contactos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_CreatedByUserId",
                table: "Ciudades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ModifiedByUserId",
                table: "Ciudades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CreatedByUserId",
                table: "Areas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ModifiedByUserId",
                table: "Areas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_CreatedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPublicacionMarketing_ModifiedByUserId",
                table: "ArchivosPublicacionMarketing",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_CreatedByUserId",
                table: "ActividadUsuarios",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadUsuarios_ModifiedByUserId",
                table: "ActividadUsuarios",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_CreatedByUserId",
                table: "Actividades",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ModifiedByUserId",
                table: "Actividades",
                column: "ModifiedByUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sectores_Usuarios_CreatedByUserId",
                table: "Sectores",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectores_Usuarios_ModifiedByUserId",
                table: "Sectores",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectoresEmpresa_Usuarios_CreatedByUserId",
                table: "SectoresEmpresa",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectoresEmpresa_Usuarios_ModifiedByUserId",
                table: "SectoresEmpresa",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsectoresEmpresa_Usuarios_CreatedByUserId",
                table: "SubsectoresEmpresa",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsectoresEmpresa_Usuarios_ModifiedByUserId",
                table: "SubsectoresEmpresa",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoActividad_Usuarios_CreatedByUserId",
                table: "TipoActividad",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoActividad_Usuarios_ModifiedByUserId",
                table: "TipoActividad",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioInterno_Usuarios_CreatedByUserId",
                table: "UsuarioInterno",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioInterno_Usuarios_ModifiedByUserId",
                table: "UsuarioInterno",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_CreatedByUserId",
                table: "Usuarios",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_ModifiedByUserId",
                table: "Usuarios",
                column: "ModifiedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Usuarios_CreatedByUserId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Usuarios_ModifiedByUserId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_CreatedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadUsuarios_Usuarios_ModifiedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivosPublicacionMarketing_Usuarios_CreatedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivosPublicacionMarketing_Usuarios_ModifiedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Usuarios_CreatedByUserId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Usuarios_ModifiedByUserId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Usuarios_CreatedByUserId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Usuarios_ModifiedByUserId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuarios_CreatedByUserId",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuarios_ModifiedByUserId",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplates_Usuarios_CreatedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplates_Usuarios_ModifiedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Usuarios_CreatedByUserId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Usuarios_ModifiedByUserId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoSalarios_Usuarios_CreatedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoSalarios_Usuarios_ModifiedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaCorreos_Usuarios_CreatedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaCorreos_Usuarios_ModifiedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Usuarios_CreatedByUserId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Usuarios_ModifiedByUserId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Especialidades_Usuarios_CreatedByUserId",
                table: "Especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Especialidades_Usuarios_ModifiedByUserId",
                table: "Especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoActividad_Usuarios_CreatedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoActividad_Usuarios_ModifiedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Usuarios_CreatedByUserId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Usuarios_ModifiedByUserId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_GoogleEventoArchivos_Usuarios_CreatedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropForeignKey(
                name: "FK_GoogleEventoArchivos_Usuarios_ModifiedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropForeignKey(
                name: "FK_GoogleEventos_Usuarios_CreatedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_GoogleEventos_Usuarios_ModifiedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialCambiosOportunidad_Usuarios_CreatedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialCambiosOportunidad_Usuarios_ModifiedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEtapaProyecto_Usuarios_CreatedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEtapaProyecto_Usuarios_ModifiedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_MetricasPublicacion_Usuarios_CreatedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_MetricasPublicacion_Usuarios_ModifiedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Oportunidades_Usuarios_CreatedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Oportunidades_Usuarios_ModifiedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosProyecto_Usuarios_CreatedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosProyecto_Usuarios_ModifiedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Usuarios_CreatedByUserId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Usuarios_ModifiedByUserId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_PrefijosTelefonicos_Usuarios_CreatedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PrefijosTelefonicos_Usuarios_ModifiedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Propuestas_Usuarios_CreatedByUserId",
                table: "Propuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Propuestas_Usuarios_ModifiedByUserId",
                table: "Propuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_CreatedByUserId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Usuarios_ModifiedByUserId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionesMarketing_Usuarios_CreatedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionesMarketing_Usuarios_ModifiedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionRedesSociales_Usuarios_CreatedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionRedesSociales_Usuarios_ModifiedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesContacto_Usuarios_CreatedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesContacto_Usuarios_ModifiedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesUsuario_Usuarios_CreatedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesUsuario_Usuarios_ModifiedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Sectores_Usuarios_CreatedByUserId",
                table: "Sectores");

            migrationBuilder.DropForeignKey(
                name: "FK_Sectores_Usuarios_ModifiedByUserId",
                table: "Sectores");

            migrationBuilder.DropForeignKey(
                name: "FK_SectoresEmpresa_Usuarios_CreatedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropForeignKey(
                name: "FK_SectoresEmpresa_Usuarios_ModifiedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsectoresEmpresa_Usuarios_CreatedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsectoresEmpresa_Usuarios_ModifiedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoActividad_Usuarios_CreatedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoActividad_Usuarios_ModifiedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioInterno_Usuarios_CreatedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioInterno_Usuarios_ModifiedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_CreatedByUserId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_ModifiedByUserId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CreatedByUserId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ModifiedByUserId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioInterno_CreatedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioInterno_ModifiedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropIndex(
                name: "IX_TipoActividad_CreatedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropIndex(
                name: "IX_TipoActividad_ModifiedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropIndex(
                name: "IX_SubsectoresEmpresa_CreatedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_SubsectoresEmpresa_ModifiedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_SectoresEmpresa_CreatedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_SectoresEmpresa_ModifiedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_Sectores_CreatedByUserId",
                table: "Sectores");

            migrationBuilder.DropIndex(
                name: "IX_Sectores_ModifiedByUserId",
                table: "Sectores");

            migrationBuilder.DropIndex(
                name: "IX_RolesUsuario_CreatedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropIndex(
                name: "IX_RolesUsuario_ModifiedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropIndex(
                name: "IX_RolesContacto_CreatedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropIndex(
                name: "IX_RolesContacto_ModifiedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionRedesSociales_CreatedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionRedesSociales_ModifiedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionesMarketing_CreatedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionesMarketing_ModifiedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_CreatedByUserId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_ModifiedByUserId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Propuestas_CreatedByUserId",
                table: "Propuestas");

            migrationBuilder.DropIndex(
                name: "IX_Propuestas_ModifiedByUserId",
                table: "Propuestas");

            migrationBuilder.DropIndex(
                name: "IX_PrefijosTelefonicos_CreatedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropIndex(
                name: "IX_PrefijosTelefonicos_ModifiedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropIndex(
                name: "IX_Paises_CreatedByUserId",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Paises_ModifiedByUserId",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_PagosProyecto_CreatedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropIndex(
                name: "IX_PagosProyecto_ModifiedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropIndex(
                name: "IX_Oportunidades_CreatedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropIndex(
                name: "IX_Oportunidades_ModifiedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropIndex(
                name: "IX_MetricasPublicacion_CreatedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropIndex(
                name: "IX_MetricasPublicacion_ModifiedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEtapaProyecto_CreatedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEtapaProyecto_ModifiedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropIndex(
                name: "IX_HistorialCambiosOportunidad_CreatedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropIndex(
                name: "IX_HistorialCambiosOportunidad_ModifiedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropIndex(
                name: "IX_GoogleEventos_CreatedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropIndex(
                name: "IX_GoogleEventos_ModifiedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropIndex(
                name: "IX_GoogleEventoArchivos_CreatedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropIndex(
                name: "IX_GoogleEventoArchivos_ModifiedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropIndex(
                name: "IX_Estados_CreatedByUserId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_ModifiedByUserId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_EstadoActividad_CreatedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropIndex(
                name: "IX_EstadoActividad_ModifiedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropIndex(
                name: "IX_Especialidades_CreatedByUserId",
                table: "Especialidades");

            migrationBuilder.DropIndex(
                name: "IX_Especialidades_ModifiedByUserId",
                table: "Especialidades");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_CreatedByUserId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_ModifiedByUserId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_EmpresaCorreos_CreatedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropIndex(
                name: "IX_EmpresaCorreos_ModifiedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropIndex(
                name: "IX_EmpleadoSalarios_CreatedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropIndex(
                name: "IX_EmpleadoSalarios_ModifiedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_CreatedByUserId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_ModifiedByUserId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_EmailTemplates_CreatedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropIndex(
                name: "IX_EmailTemplates_ModifiedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_CreatedByUserId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_ModifiedByUserId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_CreatedByUserId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_ModifiedByUserId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CreatedByUserId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ModifiedByUserId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ArchivosPublicacionMarketing_CreatedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropIndex(
                name: "IX_ArchivosPublicacionMarketing_ModifiedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropIndex(
                name: "IX_ActividadUsuarios_CreatedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_ActividadUsuarios_ModifiedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_CreatedByUserId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_ModifiedByUserId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UsuarioInterno");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "UsuarioInterno");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "UsuarioInterno");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TipoActividad");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "TipoActividad");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "TipoActividad");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "SubsectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "SectoresEmpresa");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Sectores");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Sectores");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Sectores");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Sectores");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RolesUsuario");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RolesUsuario");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "RolesUsuario");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RolesContacto");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RolesContacto");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "RolesContacto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "PublicacionRedesSociales");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PublicacionesMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "PublicacionesMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "PublicacionesMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "PrefijosTelefonicos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PagosProyecto");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "PagosProyecto");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "PagosProyecto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Oportunidades");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Oportunidades");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Oportunidades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MetricasPublicacion");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "MetricasPublicacion");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "MetricasPublicacion");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "HistorialesEtapaProyecto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "HistorialCambiosOportunidad");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "GoogleEventos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "GoogleEventoArchivos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EstadoActividad");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EstadoActividad");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "EstadoActividad");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmpresaCorreos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EmpresaCorreos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "EmpresaCorreos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmpleadoSalarios");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EmpleadoSalarios");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "EmpleadoSalarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "ArchivosPublicacionMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ActividadUsuarios");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ActividadUsuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "ActividadUsuarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Actividades");
        }
    }
}
