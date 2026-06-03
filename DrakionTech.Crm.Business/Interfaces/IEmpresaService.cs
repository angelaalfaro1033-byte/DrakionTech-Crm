using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empresa;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEmpresaService
    {
        Task<ResultadoPaginacion<EmpresaDto>>ObtenerTodasConPaginacionAsync(string? busqueda = null, bool? soloActivas = null, int pagina = 1, int tamañoPagina = 10, CancellationToken ct = default);
        Task<int> CrearAsync(CrearEmpresaDto dto, CancellationToken ct = default);
        Task ActualizarAsync(int empresaId, ActualizarEmpresaDto dto, CancellationToken ct = default);
        Task<EmpresaDto> ObtenerPorIdAsync(int empresaId, CancellationToken ct = default);
        Task<IEnumerable<EmpresaDto>> ObtenerTodasAsync(string? busqueda = null, bool? soloActivas = null, CancellationToken ct = default);
        Task ActivarAsync(int empresaId, CancellationToken ct = default);
        Task DesactivarAsync(int empresaId, CancellationToken ct = default);
    }
}