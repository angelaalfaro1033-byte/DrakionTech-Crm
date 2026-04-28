using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using DrakionTech.Crm.Business.DTOs.Empleado;
using DrakionTech.Crm.Business.Services.Email;
using Microsoft.Extensions.Configuration;
namespace DrakionTech.Crm.Business.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public EmpleadoService(
    IEmpleadoRepository repository,
    IEmailService emailService,
    IConfiguration config)
        {
            _repository = repository;
            _emailService = emailService;
            _config = config;
        }

        public async Task<List<EmpleadoListDto>> ObtenerTodosAsync()
        {
            var empleados = await _repository.GetAllAsync();
            return empleados.Select(MapToDto).ToList();
        }

        public async Task<EmpleadoListDto> ObtenerPorIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Empleado no encontrado");

            return MapToDto(e);
        }

        public async Task CrearAsync(CrearEmpleadoDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("El email es obligatorio");

            var token = Guid.NewGuid().ToString();

            var empleado = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Cargo = dto.Cargo,
                Rol = dto.Rol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow,

                IsActive = false,
                ActivationToken = token,
                ActivationTokenExpiration = DateTime.UtcNow.AddHours(24)
            };


            await _repository.AddAsync(empleado);

            var baseUrl = _config["App:BaseUrl"];


            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("App:BaseUrl no está configurado");

            var link = $"{baseUrl}/activate?token={token}";

            await _emailService.SendTemplateAsync(
                empleado.Email,
                "ActivacionCuenta",
                new Dictionary<string, string>
                {
            { "Nombre", empleado.Nombre },
            { "ActivationLink", link }
                });
        }

        public async Task<bool> ActivarCuentaAsync(string token, string password)
        {
            var empleado = (await _repository.GetAllAsync())
                .FirstOrDefault(x => x.ActivationToken == token);

            if (empleado == null)
                return false;

            if (empleado.ActivationTokenExpiration < DateTime.UtcNow)
                return false;

            empleado.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            empleado.IsActive = true;
            empleado.ActivationToken = null;

            await _repository.UpdateAsync(empleado);

            return true;
        } 
        public async Task EditarAsync(ActualizarEmpleadoDto dto)
        {
            var empleado = await _repository.GetByIdAsync(dto.Id)
                ?? throw new Exception("Empleado no encontrado");

            empleado.Nombre = dto.Nombre;
            empleado.Apellido = dto.Apellido;
            empleado.Email = dto.Email;
            empleado.Cargo = dto.Cargo;
            empleado.Rol = dto.Rol;
            empleado.FechaModificacion = DateTime.UtcNow;

            await _repository.UpdateAsync(empleado);
        }

        public async Task DesactivarAsync(int id)
        {
            var empleado = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Empleado no encontrado");

            empleado.Activo = false;
            empleado.FechaModificacion = DateTime.UtcNow;

            await _repository.UpdateAsync(empleado);
        }
        private static EmpleadoListDto MapToDto(Empleado e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Email = e.Email,
            Cargo = e.Cargo,
            Rol = e.Rol,
            Activo = e.Activo
        };
    }
}