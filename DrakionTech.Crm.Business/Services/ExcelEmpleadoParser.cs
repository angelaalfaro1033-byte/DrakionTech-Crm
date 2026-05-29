using DrakionTech.Crm.Business.DTOs.Empleado;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities.Enums;
using OfficeOpenXml;

namespace DrakionTech.Crm.Business.Services
{
    public class ExcelEmpleadoParser : IExcelEmpleadoParser
    {
        public List<EmpleadoExcelRowDto> Parse(Stream stream)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var filas = new List<EmpleadoExcelRowDto>();

            using var package = new ExcelPackage(stream);
            var hoja = package.Workbook.Worksheets[0];
            int totalFilas = hoja.Dimension?.Rows ?? 0;

            for (int i = 2; i <= totalFilas; i++)
            {
                var tipoDocRaw = hoja.Cells[i, 1].Text.Trim();
                if (string.IsNullOrWhiteSpace(tipoDocRaw)) continue;

                filas.Add(new EmpleadoExcelRowDto
                {
                    TipoDocumento = NormalizarTipoDocumento(tipoDocRaw),
                    NumeroDocumento = hoja.Cells[i, 2].Text.Trim(),
                    Nombre = hoja.Cells[i, 3].Text.Trim(),
                    Apellido = hoja.Cells[i, 4].Text.Trim(),
                    Email = hoja.Cells[i, 5].Text.Trim(),
                    Rol = hoja.Cells[i, 6].Text.Trim(),
                    Especialidad = hoja.Cells[i, 7].Text.Trim(),
                    Salario = decimal.TryParse(hoja.Cells[i, 8].Text.Trim(), out var s) ? s : 0
                });
            }

            return filas;
        }

        private static string NormalizarTipoDocumento(string valor)
        {
            var limpio = valor.Replace(".", "").Replace(" ", "").Replace("-", "").ToUpperInvariant();

            return limpio switch
            {
                "CC" or "CEDULACIUDADANIA" or "CÉDULACIUDADANÍA"
                      or "CEDCIUDADANIA" => nameof(TipoDocumento.CC),

                "CE" or "CEDULAEXTRANJERIA" or "CÉDULAEXTRANJERÍIA"
                      or "CEDEXTRANJERIA" or "CEDULAEXTRANJERÍA" => nameof(TipoDocumento.CE),

                "PA" or "PASAPORTE" => nameof(TipoDocumento.PA),

                "RC" or "REGISTROCIVIL" => nameof(TipoDocumento.RC),

                "TI" or "TARJETAIDENTIDAD" or "TARJETADEIDENTIDAD" => nameof(TipoDocumento.TI),

                "NIT" or "NITEMPRESA" => nameof(TipoDocumento.NIT),

                _ => valor
            };
        }
    }
}