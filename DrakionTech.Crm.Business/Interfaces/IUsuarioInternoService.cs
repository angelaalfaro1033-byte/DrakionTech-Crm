using DrakionTech.Crm.Business.DTOs.UsuarioInterno;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IUsuarioInternoService
    {
        Task<int> CrearAsync(
            CrearUsuarioInternoDto dto,
            CancellationToken ct = default);

        Task ActualizarAsync(
            int usuarioId,
            ActualizarUsuarioInternoDto dto,
            CancellationToken ct = default);

        Task<UsuarioInternoDto> ObtenerPorIdAsync(
            int usuarioId,
            CancellationToken ct = default);

        Task<IEnumerable<UsuarioInternoDto>> ObtenerActivosAsync(
            CancellationToken ct = default);

        Task<IEnumerable<UsuarioInternoDto>> ObtenerTodosAsync(
            CancellationToken ct = default);
    }
}