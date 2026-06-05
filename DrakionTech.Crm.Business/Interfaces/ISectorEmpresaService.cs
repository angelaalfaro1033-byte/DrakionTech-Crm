using DrakionTech.Crm.Business.DTOs.SectorEmpresa;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface ISectorEmpresaService
    {
        Task<IEnumerable<SectorEmpresaDto>> ObtenerTodosAsync(CancellationToken ct = default);
        Task<SectorEmpresaDto> CrearYObtenerAsync(string nombre, CancellationToken ct = default);

        Task<IEnumerable<SubsectorEmpresaDto>> ObtenerSubsectoresPorSectorAsync(int sectorId, CancellationToken ct = default);
        Task<SubsectorEmpresaDto> CrearSubsectorYObtenerAsync(string nombre, int sectorId, CancellationToken ct = default);
    }
}