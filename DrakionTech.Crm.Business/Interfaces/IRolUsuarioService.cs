using DrakionTech.Crm.Business.DTOs.RolUsuario;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IRolUsuarioService
    {
        Task<List<RolUsuarioDto>> ObtenerTodosAsync();
        Task<RolUsuarioDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(RolUsuarioDto dto);
        Task EditarAsync(RolUsuarioDto dto);
        Task DesactivarAsync(int id);
        Task ActivarAsync(int id);
    }
}