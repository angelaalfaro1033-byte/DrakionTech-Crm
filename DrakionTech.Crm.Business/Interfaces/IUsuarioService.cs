using DrakionTech.Crm.Business.DTOs.Usuario;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IUsuarioService
{
    Task<List<UsuarioListDto>> ObtenerTodosAsync();
    Task<UsuarioListDto> ObtenerPorIdAsync(int id);
    Task CrearAsync(CrearUsuarioDto dto);
    Task EditarAsync(ActualizarUsuarioDto dto);
    Task DesactivarAsync(int id);

    Task ActivarAsync(int id);
    Task<bool> ActivarCuentaAsync(string token, string password);
    Task<bool> ExisteAlgunUsuarioAsync();
}