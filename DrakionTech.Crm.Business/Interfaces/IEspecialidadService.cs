using DrakionTech.Crm.Business.DTOs.Especialidad;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null);
        Task<EspecialidadDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(EspecialidadDto dto);
        Task EditarAsync(EspecialidadDto dto);
        Task ActivarAsync(int id);
        Task DesactivarAsync(int id);
        Task<EspecialidadDto> CrearYObtenerAsync(string nombre, int rolUsuarioId);
    }
}