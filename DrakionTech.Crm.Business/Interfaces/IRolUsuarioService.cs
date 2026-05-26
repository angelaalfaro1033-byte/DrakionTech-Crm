using DrakionTech.Crm.Business.DTOs.RolUsuario;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IRolUsuarioService
    {
        Task<List<RolUsuarioDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null);
        Task<RolUsuarioDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(RolUsuarioDto dto);
        Task EditarAsync(RolUsuarioDto dto);
        Task DesactivarAsync(int id);
        Task ActivarAsync(int id);
        Task<RolUsuarioDto> CrearYObtenerAsync(string nombre);
    }
}