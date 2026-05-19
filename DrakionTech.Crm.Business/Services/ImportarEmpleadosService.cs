using DrakionTech.Crm.Business.DTOs.Empleado;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DrakionTech.Crm.Business.Services
{
    public class ImportarEmpleadosService : IImportarEmpleadosService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IExcelEmpleadoParser _parser;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public ImportarEmpleadosService(
            IEmpleadoRepository repository,
            IExcelEmpleadoParser parser,
            IEmailService emailService,
            IConfiguration config)
        {
            _repository = repository;
            _parser = parser;
            _emailService = emailService;
            _config = config;
        }

        public async Task<ImportarEmpleadosResultDto> ImportarAsync(Stream stream)
        {
            var resultado = new ImportarEmpleadosResultDto();
            var filas = _parser.Parse(stream);

            foreach (var fila in filas)
            {
                try
                {
                    var existente = await _repository.ObtenerPorEmailAsync(fila.Email);

                    if (!Enum.TryParse<TipoDocumento>(fila.TipoDocumento, out var tipoDoc))
                    {
                        resultado.Errores.Add($"Fila con email '{fila.Email}': TipoDocumento '{fila.TipoDocumento}' no válido.");
                        continue;
                    }

                    if (existente is null)
                    {
                        var token = Guid.NewGuid().ToString();
                        var nuevo = new Empleado
                        {
                            Nombre = fila.Nombre,
                            Apellido = fila.Apellido,
                            Email = fila.Email,
                            Cargo = fila.Cargo,
                            Rol = fila.Rol,
                            TipoDocumento = tipoDoc,
                            NumeroDocumento = fila.NumeroDocumento,
                            Activo = true,
                            FechaCreacion = DateTime.UtcNow,
                            IsActive = false,
                            ActivationToken = token,
                            ActivationTokenExpiration = DateTime.UtcNow.AddHours(24),
                            Salario = new EmpleadoSalario { Salario = fila.Salario }
                        };

                        await _repository.AgregarAsync(nuevo);

                        var baseUrl = _config["App:BaseUrl"] ?? "";
                        var link = $"{baseUrl}/activate?token={token}";
                        await _emailService.SendTemplateAsync(nuevo.Email, "ActivacionCuenta",
                            new Dictionary<string, string>
                            {
                                { "Nombre", nuevo.Nombre },
                                { "ActivationLink", link }
                            });

                        resultado.Creados++;
                    }
                    else
                    {
                        existente.Nombre = fila.Nombre;
                        existente.Apellido = fila.Apellido;
                        existente.Cargo = fila.Cargo;
                        existente.Rol = fila.Rol;
                        existente.TipoDocumento = tipoDoc;
                        existente.NumeroDocumento = fila.NumeroDocumento;
                        existente.FechaModificacion = DateTime.UtcNow;

                        if (existente.Salario is null)
                            existente.Salario = new EmpleadoSalario { Salario = fila.Salario };
                        else
                        {
                            existente.Salario.Salario = fila.Salario;
                            existente.Salario.FechaModificacion = DateTime.UtcNow;
                        }

                        await _repository.ActualizarAsync(existente);
                        resultado.Actualizados++;
                    }
                }
                catch (Exception ex)
                {
                    resultado.Errores.Add($"Error en '{fila.Email}': {ex.Message}");
                }
            }

            return resultado;
        }
    }
}