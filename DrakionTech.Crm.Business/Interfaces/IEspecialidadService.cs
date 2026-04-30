using DrakionTech.Crm.Business.DTOs.Especialidad;
using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadDto>> ObtenerTodosAsync();
        Task<EspecialidadDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(EspecialidadDto dto);
        Task EditarAsync(EspecialidadDto dto);
        Task ActivarAsync(int id);
        Task DesactivarAsync(int id);
    }
}