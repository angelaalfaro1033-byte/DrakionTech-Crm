using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrakionTech.Crm.Data.Migrations
{
    /// <inheritdoc />
    public partial class ciudades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 46, "La Paz", 3 },
                    { 47, "Quito", 6 },
                    { 48, "Georgetown", 7 },
                    { 49, "Asunción", 8 },
                    { 50, "Paramaribo", 10 },
                    { 51, "Montevideo", 11 },
                    { 52, "Caracas", 12 }
                });

            migrationBuilder.InsertData(
                table: "PrefijosTelefonicos",
                columns: new[] { "Id", "Codigo", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 3, "+54", "Argentina", 2 },
                    { 4, "+591", "Bolivia", 3 },
                    { 5, "+55", "Brasil", 4 },
                    { 6, "+56", "Chile", 5 },
                    { 7, "+593", "Ecuador", 6 },
                    { 8, "+592", "Guyana", 7 },
                    { 9, "+595", "Paraguay", 8 },
                    { 10, "+51", "Perú", 9 },
                    { 11, "+597", "Surinam", 10 },
                    { 12, "+598", "Uruguay", 11 },
                    { 13, "+58", "Venezuela", 12 },
                    { 14, "+52", "México", 13 },
                    { 15, "+1", "Canadá", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PrefijosTelefonicos",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
