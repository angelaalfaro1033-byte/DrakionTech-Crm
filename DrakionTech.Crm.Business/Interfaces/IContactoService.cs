using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.DTOs.Contacto;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IContactoService
    {
        Task<int> CrearAsync(CrearContactoDto dto, CancellationToken ct = default);

        Task ActualizarAsync(int contactoId, ActualizarContactoDto dto, CancellationToken ct = default);

        Task<ContactoDto> ObtenerPorIdAsync(int contactoId, CancellationToken ct = default);

        Task<IEnumerable<ContactoDto>> ObtenerPorEmpresaAsync(int empresaId, CancellationToken ct = default);

        Task<IEnumerable<CatalogoDto>> ObtenerRolesContactoAsync(CancellationToken ct = default);
    }
}