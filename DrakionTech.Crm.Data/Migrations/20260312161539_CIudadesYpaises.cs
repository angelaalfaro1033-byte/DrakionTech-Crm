using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class CIudadesYpaises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nombre", "PaisId" },
                values: new object[] { "Cali", 1 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 4, "Barranquilla", 1 },
                    { 5, "Cartagena", 1 },
                    { 6, "Bucaramanga", 1 },
                    { 7, "Cúcuta", 1 },
                    { 8, "Pereira", 1 },
                    { 9, "Manizales", 1 },
                    { 10, "Armenia", 1 },
                    { 11, "Ibagué", 1 },
                    { 12, "Neiva", 1 },
                    { 13, "Villavicencio", 1 },
                    { 14, "Pasto", 1 },
                    { 15, "Popayán", 1 },
                    { 16, "Santa Marta", 1 },
                    { 17, "Valledupar", 1 },
                    { 18, "Montería", 1 },
                    { 19, "Sincelejo", 1 },
                    { 20, "Riohacha", 1 },
                    { 21, "Yopal", 1 },
                    { 22, "Tunja", 1 },
                    { 23, "Florencia", 1 },
                    { 24, "Mocoa", 1 },
                    { 25, "San José del Guaviare", 1 },
                    { 26, "Leticia", 1 },
                    { 27, "Mitú", 1 },
                    { 28, "Puerto Carreño", 1 },
                    { 29, "Quibdó", 1 },
                    { 30, "Arauca", 1 },
                    { 31, "San Andrés", 1 },
                    { 32, "Inírida", 1 },
                    { 33, "Buenaventura", 1 },
                    { 34, "Buenos Aires", 2 },
                    { 35, "Córdoba", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CodigoIso", "Nombre" },
                values: new object[] { "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "CodigoIso", "Nombre" },
                values: new object[,]
                {
                    { 3, "BO", "Bolivia" },
                    { 4, "BR", "Brasil" },
                    { 5, "CL", "Chile" },
                    { 6, "EC", "Ecuador" },
                    { 7, "GY", "Guyana" },
                    { 8, "PY", "Paraguay" },
                    { 9, "PE", "Perú" },
                    { 10, "SR", "Surinam" },
                    { 11, "UY", "Uruguay" },
                    { 12, "VE", "Venezuela" },
                    { 13, "MX", "México" },
                    { 14, "US", "Estados Unidos" },
                    { 15, "CA", "Canadá" }
                });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaisId",
                value: 14);

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 36, "São Paulo", 4 },
                    { 37, "Rio de Janeiro", 4 },
                    { 38, "Santiago", 5 },
                    { 39, "Lima", 9 },
                    { 40, "Ciudad de México", 13 },
                    { 41, "Monterrey", 13 },
                    { 42, "New York", 14 },
                    { 43, "Los Ángeles", 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nombre", "PaisId" },
                values: new object[] { "Nueva York", 2 });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CodigoIso", "Nombre" },
                values: new object[] { "EEUU", "Estados Unidos" });

            migrationBuilder.UpdateData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaisId",
                value: 2);
        }
    }
}
