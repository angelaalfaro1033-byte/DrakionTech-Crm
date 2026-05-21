using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Especialidad;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IEspecialidadRepository _repository;

        public EspecialidadService(IEspecialidadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EspecialidadDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosConRolAsync();
            return lista.Select(MapToDto).ToList();
        }

        public async Task<EspecialidadDto> ObtenerPorIdAsync(int id)
        {
            var lista = await _repository.ObtenerTodosConRolAsync();
            var e = lista.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            return MapToDto(e);
        }

        public async Task CrearAsync(EspecialidadDto dto)
        {
            var lista = await _repository.ObtenerTodosConRolAsync();

            var duplicado = lista.Any(e =>
                e.Nombre.Trim().ToLower() == dto.Nombre.Trim().ToLower() &&
                e.RolUsuarioId == dto.RolUsuarioId);

            if (duplicado)
                throw new Exception(string.Format(MensajesError.EspecialidadDuplicada, dto.Nombre));

            var entidad = new Especialidad
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                RolUsuarioId = dto.RolUsuarioId,
                Activo = true
            };

            await _repository.AgregarAsync(entidad);
        }

        public async Task EditarAsync(EspecialidadDto dto)
        {
            var lista = await _repository.ObtenerTodosConRolAsync();

            var duplicado = lista.Any(e =>
                e.Id != dto.Id &&
                e.Nombre.Trim().ToLower() == dto.Nombre.Trim().ToLower() &&
                e.RolUsuarioId == dto.RolUsuarioId);

            if (duplicado)
                throw new Exception(string.Format(MensajesError.EspecialidadDuplicada, dto.Nombre));

            var entidad = await _repository.ObtenerPorIdAsync(dto.Id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);

            entidad.Nombre = dto.Nombre;
            entidad.Descripcion = dto.Descripcion;
            entidad.RolUsuarioId = dto.RolUsuarioId;
            entidad.Activo = dto.Activo;

            await _repository.ActualizarAsync(entidad);
        }

        public async Task ActivarAsync(int id)
        {
            var entidad = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            entidad.Activo = true;
            await _repository.ActualizarAsync(entidad);
        }

        public async Task DesactivarAsync(int id)
        {
            var entidad = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.EspecialidadNoEncontrada);
            entidad.Activo = false;
            await _repository.ActualizarAsync(entidad);
        }

        private static EspecialidadDto MapToDto(Especialidad e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Descripcion = e.Descripcion,
            RolUsuarioId = e.RolUsuarioId,
            RolUsuarioNombre = e.RolUsuario?.Nombre,
            Activo = e.Activo
        };
    }
}