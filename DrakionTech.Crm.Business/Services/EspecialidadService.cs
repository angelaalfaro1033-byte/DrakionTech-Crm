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
            var lista = await _repository.GetAllWithRolAsync();
            return lista.Select(MapToDto).ToList();
        }

        public async Task<EspecialidadDto> ObtenerPorIdAsync(int id)
        {
            var lista = await _repository.GetAllWithRolAsync();
            var e = lista.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Especialidad no encontrada");
            return MapToDto(e);
        }

        public async Task CrearAsync(EspecialidadDto dto)
        {
            var entidad = new Especialidad
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                RolUsuarioId = dto.RolUsuarioId,
                Activo = true
            };
            await _repository.AddAsync(entidad);
        }

        public async Task EditarAsync(EspecialidadDto dto)
        {
            var entidad = await _repository.GetByIdAsync(dto.Id)
                ?? throw new Exception("Especialidad no encontrada");

            entidad.Nombre = dto.Nombre;
            entidad.Descripcion = dto.Descripcion;
            entidad.RolUsuarioId = dto.RolUsuarioId;
            entidad.Activo = dto.Activo;

            await _repository.UpdateAsync(entidad);
        }

        public async Task ActivarAsync(int id)
        {
            var entidad = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Especialidad no encontrada");
            entidad.Activo = true;
            await _repository.UpdateAsync(entidad);
        }

        public async Task DesactivarAsync(int id)
        {
            var entidad = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Especialidad no encontrada");
            entidad.Activo = false;
            await _repository.UpdateAsync(entidad);
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