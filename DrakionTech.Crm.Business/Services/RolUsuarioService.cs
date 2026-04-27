using DrakionTech.Crm.Business.DTOs.RolUsuario;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _repository;

        public RolUsuarioService(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }

        // =========================
        // GET ALL
        // =========================
        public async Task<List<RolUsuarioDto>> ObtenerTodosAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(MapToDto).ToList();
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<RolUsuarioDto> ObtenerPorIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Rol no encontrado");

            return MapToDto(rol);
        }

        // =========================
        // CREATE
        // =========================
        public async Task CrearAsync(RolUsuarioDto dto)
        {
            var rol = new RolUsuario
            {
                Nombre = dto.Nombre
            };

            await _repository.AddAsync(rol);
        }

        // =========================
        // UPDATE
        // =========================
        public async Task EditarAsync(RolUsuarioDto dto)
        {
            var rol = await _repository.GetByIdAsync(dto.Id)
                ?? throw new Exception("Rol no encontrado");

            rol.Nombre = dto.Nombre;
            rol.Activo = dto.Activo;

            await _repository.UpdateAsync(rol);
        }

        // =========================
        // ACTIVATE ROLE
        // =========================
        public async Task DesactivarAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Rol no encontrado");
            rol.Activo = false;
            await _repository.UpdateAsync(rol);
        }

        // =========================
        // DEACTIVATE ROLE
        // =========================
        public async Task ActivarAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Rol no encontrado");
            rol.Activo = true;
            await _repository.UpdateAsync(rol);
        }
        // =========================
        // MAPPER
        // =========================
        private static RolUsuarioDto MapToDto(RolUsuario r) => new()
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Activo = r.Activo,
        };
    }
}