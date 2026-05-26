using DrakionTech.Crm.Business.DTOs.Area;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IAreaService
{
    Task<IEnumerable<AreaListDto>> ObtenerTodasAsync(string? busqueda = null, bool? soloActivas = null);

    Task<AreaDto?> ObtenerPorIdAsync(int id);

    Task<AreaDto> CrearAsync(CrearAreaDto dto);

    Task<AreaDto> ActualizarAsync(int id, ActualizarAreaDto dto);

    Task<bool> NombreExisteAsync(string nombre, int? excluirId = null);

    Task CambiarEstadoAsync(int id, bool activa);
}