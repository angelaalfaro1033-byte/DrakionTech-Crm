using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using DrakionTech.Crm.Business.DTOs.Empleado;

namespace DrakionTech.Crm.Business.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoService(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        // =========================
        // GET ALL
        // =========================
        public async Task<List<EmpleadoListDto>> ObtenerTodosAsync()
        {
            var empleados = await _repository.GetAllAsync();
            return empleados.Select(MapToDto).ToList();
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<EmpleadoListDto> ObtenerPorIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Empleado no encontrado");

            return MapToDto(e);
        }

        // =========================
        // CREATE
        // =========================
        public async Task CrearAsync(CrearEmpleadoDto dto)
        {
            var empleado = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Cargo = dto.Cargo,
                Rol = dto.Rol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            await _repository.AddAsync(empleado);
        }

        // =========================
        // UPDATE
        // =========================
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

        // =========================
        // DEACTIVATE
        // =========================
        public async Task DesactivarAsync(int id)
        {
            var empleado = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Empleado no encontrado");

            empleado.Activo = false;
            empleado.FechaModificacion = DateTime.UtcNow;

            await _repository.UpdateAsync(empleado);
        }

        // =========================
        // MAPPER (CLAVE)
        // =========================
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