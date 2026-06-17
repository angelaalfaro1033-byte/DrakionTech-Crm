using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Business.DTOs.Empresa;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IHistorialEmpresaService
{
    Task<ResultadoPaginacion<HistorialEmpresaDto>> ObtenerPorEmpresaAsync(
        FiltroHistorialEmpresaDto filtro,
        CancellationToken ct = default);

    Task<HistorialEmpresaDto?> ObtenerPorIdAsync(int historialEmpresaId, CancellationToken ct = default);

    Task<int> RegistrarAsync(RegistrarHistorialEmpresaDto dto, CancellationToken ct = default);

    Task<int> SincronizarEmpresaAsync(int empresaId, CancellationToken ct = default);

    Task<bool> ExisteEventoAsync(string claveEvento, CancellationToken ct = default);

    IEnumerable<OpcionEnumDto> ObtenerTiposEvento();

    IEnumerable<OpcionEnumDto> ObtenerModulosOrigen();
}
