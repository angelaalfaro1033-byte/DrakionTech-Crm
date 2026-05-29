using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empleado;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using DrakionTech.Crm.Data.Repositories.Interfaces;

namespace DrakionTech.Crm.Business.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IEspecialidadRepository _especialidadRepository;

        public EmpleadoService(
            IEmpleadoRepository repository,
            IEspecialidadRepository especialidadRepository)
        {
            _repository = repository;
            _especialidadRepository = especialidadRepository;
        }

        public async Task<List<EmpleadoListDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null)
        {
            var empleados = await _repository.ObtenerTodosAsync();

            var query = empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(e =>
                    (e.Nombre != null && e.Nombre.ToLower().Contains(term)) ||
                    (e.Apellido != null && e.Apellido.ToLower().Contains(term)) ||
                    (e.Email != null && e.Email.ToLower().Contains(term)) ||
                    (e.EspecialidadNavigation != null && e.EspecialidadNavigation.Nombre.ToLower().Contains(term)));
            }

            if (soloActivos.HasValue)
                query = query.Where(e => e.Activo == soloActivos.Value);

            return query.Select(MapToDto).ToList();
        }

        public async Task<EmpleadoListDto> ObtenerPorIdAsync(int id)
        {
            var e = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.EmpleadoNoEncontrado);

            return MapToDto(e);
        }

        public async Task CrearAsync(CrearEmpleadoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception(MensajesError.EmailObligatorio);

            var errores = new List<string>();

            var documentoExistente = await _repository.ObtenerPorNumeroDocumentoAsync(dto.NumeroDocumento);
            if (documentoExistente != null)
                errores.Add(MensajesError.DocumentoEmpleadoDuplicado);

            var empleadoExistente = await _repository.ObtenerPorEmailAsync(dto.Email);
            if (empleadoExistente != null)
                errores.Add(MensajesError.EmailEmpleadoDuplicado);

            var compatible = await _especialidadRepository
                .ExisteEspecialidadEnRolAsync(dto.EspecialidadId, dto.RolUsuarioId);
            if (!compatible)
                errores.Add(MensajesError.EspecialidadIncompatible);

            if (errores.Any())
                throw new Exception(string.Join(" | ", errores));

            var empleado = new Empleado
            {
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                RolUsuarioId = dto.RolUsuarioId,
                EspecialidadId = dto.EspecialidadId,
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                Salario = dto.Salario.HasValue
                    ? new EmpleadoSalario { Salario = dto.Salario.Value }
                    : null,
            };

            await _repository.AgregarAsync(empleado);
        }

        public async Task EditarAsync(ActualizarEmpleadoDto dto)
        {
            var empleado = await _repository.ObtenerPorIdAsync(dto.Id)
                ?? throw new Exception(MensajesError.EmpleadoNoEncontrado);

            var compatible = await _especialidadRepository
                .ExisteEspecialidadEnRolAsync(dto.EspecialidadId, dto.RolUsuarioId);
            if (!compatible)
                throw new Exception(MensajesError.EspecialidadIncompatible);

            empleado.Nombre = dto.Nombre;
            empleado.Apellido = dto.Apellido;
            empleado.Email = dto.Email;
            empleado.RolUsuarioId = dto.RolUsuarioId;
            empleado.EspecialidadId = dto.EspecialidadId;
            empleado.FechaModificacion = DateTime.UtcNow;
            empleado.TipoDocumento = dto.TipoDocumento;
            empleado.NumeroDocumento = dto.NumeroDocumento;

            if (dto.Salario.HasValue)
            {
                if (empleado.Salario is null)
                    empleado.Salario = new EmpleadoSalario { Salario = dto.Salario.Value };
                else
                {
                    empleado.Salario.Salario = dto.Salario.Value;
                    empleado.Salario.FechaModificacion = DateTime.UtcNow;
                }
            }

            await _repository.ActualizarAsync(empleado);
        }

        public async Task DesactivarAsync(int id)
        {
            var empleado = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.EmpleadoNoEncontrado);

            empleado.Activo = false;
            empleado.FechaModificacion = DateTime.UtcNow;

            await _repository.ActualizarAsync(empleado);
        }

        public async Task ActivarAsync(int id)
        {
            var empleado = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.EmpleadoNoEncontrado);

            empleado.Activo = true;
            empleado.FechaModificacion = DateTime.UtcNow;

            await _repository.ActualizarAsync(empleado);
        }

        private static EmpleadoListDto MapToDto(Empleado e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Email = e.Email,
            RolUsuarioId = e.RolUsuarioId,
            RolNombre = e.RolUsuario?.Nombre,
            EspecialidadId = e.EspecialidadId,
            Especialidad = e.EspecialidadNavigation?.Nombre,
            Activo = e.Activo,
            TipoDocumento = e.TipoDocumento,
            NumeroDocumento = e.NumeroDocumento,
            Salario = e.Salario?.Salario
        };

        public async Task<EmpleadoListDto?> ObtenerPorEmailAsync(string email)
        {
            var e = await _repository.ObtenerPorEmailAsync(email);
            return e is null ? null : MapToDto(e);
        }
    }
}