using DrakionTech.Crm.Business.DTOs.Empresa;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IEmpresaService
    {
        Task<int> CrearAsync(CrearEmpresaDto dto, CancellationToken ct = default);

        Task ActualizarAsync(int empresaId, ActualizarEmpresaDto dto, CancellationToken ct = default);

        Task<EmpresaDto> ObtenerPorIdAsync(int empresaId, CancellationToken ct = default);

        Task<IEnumerable<EmpresaDto>> ObtenerTodasAsync(CancellationToken ct = default);
    }
}