using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities.Enums;
using OfficeOpenXml;

namespace DrakionTech.Crm.Business.Services
{
    public class PlantillaEmpleadoService : IPlantillaEmpleadoService
    {
        private static readonly string[] Encabezados =
[
            "TipoDocumento", "NumeroDocumento", "Nombre",
            "Apellido", "Email", "Rol", "Especialidad", "Salario"
        ];

        public byte[] GenerarPlantillaExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var tiposValidos = string.Join(", ", Enum.GetNames<TipoDocumento>());
            var primerTipo = Enum.GetNames<TipoDocumento>().First();

            using var package = new ExcelPackage();
            var hoja = package.Workbook.Worksheets.Add("Empleados");

            for (int col = 0; col < Encabezados.Length; col++)
            {
                var celda = hoja.Cells[1, col + 1];
                celda.Value = Encabezados[col];
                celda.Style.Font.Bold = true;
            }

            var ejemplo = new string[]
            {
                primerTipo, "1234567890", "Juan",
                "Pérez", "juan.perez@empresa.com", "Desarrollador", "JS", "3500000"
            };

            for (int col = 0; col < ejemplo.Length; col++)
                hoja.Cells[2, col + 1].Value = ejemplo[col];

            hoja.Cells[3, 1].Value = $"Valores válidos para TipoDocumento: {tiposValidos}";
            hoja.Cells[3, 1, 3, Encabezados.Length].Merge = true;
            hoja.Cells[3, 1].Style.Font.Italic = true;
            hoja.Cells[3, 1].Style.Font.Size = 9;

            hoja.Cells[hoja.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}