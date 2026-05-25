using DrakionTech.Crm.Business.Common;
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

        public async Task<List<RolUsuarioDto>> ObtenerTodosAsync()
        {
            var roles = await _repository.ObtenerTodosAsync();
            return roles.Select(MapToDto).ToList();
        }

        public async Task<RolUsuarioDto> ObtenerPorIdAsync(int id)
        {
            var rol = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);

            return MapToDto(rol);
        }

        public async Task CrearAsync(RolUsuarioDto dto)
        {
            var rol = new RolUsuario
            {
                Nombre = dto.Nombre
            };

            await _repository.AgregarAsync(rol);
        }

        public async Task EditarAsync(RolUsuarioDto dto)
        {
            var rol = await _repository.ObtenerPorIdAsync(dto.Id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);

            rol.Nombre = dto.Nombre;
            rol.Activo = dto.Activo;

            await _repository.ActualizarAsync(rol);
        }

        public async Task DesactivarAsync(int id)
        {
            var rol = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            rol.Activo = false;
            await _repository.ActualizarAsync(rol);
        }

        public async Task ActivarAsync(int id)
        {
            var rol = await _repository.ObtenerPorIdAsync(id)
                ?? throw new Exception(MensajesError.RolNoEncontrado);
            rol.Activo = true;
            await _repository.ActualizarAsync(rol);
        }

        private static RolUsuarioDto MapToDto(RolUsuario r) => new()
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Activo = r.Activo,
        };

        public async Task<RolUsuarioDto> CrearYObtenerAsync(string nombre)
        {
            var todos = await _repository.ObtenerTodosAsync();
            var existente = todos.FirstOrDefault(r =>
                Normalizar(r.Nombre) == Normalizar(nombre));

            if (existente is not null)
                return MapToDto(existente);

            var nuevo = new RolUsuario { Nombre = nombre.Trim(), Activo = true };
            await _repository.AgregarAsync(nuevo);
            return MapToDto(nuevo);
        }

        private static string Normalizar(string texto) =>
            string.Concat(
                texto.Trim().ToLowerInvariant()
                    .Normalize(System.Text.NormalizationForm.FormD)
                    .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                        != System.Globalization.UnicodeCategory.NonSpacingMark)
            );
    }
}