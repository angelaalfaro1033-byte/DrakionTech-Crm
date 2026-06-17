using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Empresa;

public class FiltroHistorialEmpresaDto
{
    public int EmpresaId { get; set; }
    public DateTime? FechaDesde { get; set; }
    public DateTime? FechaHasta { get; set; }
    public TipoEventoHistorialEmpresa? TipoEvento { get; set; }
    public ModuloOrigenHistorialEmpresa? ModuloOrigen { get; set; }
    public string? Busqueda { get; set; }
    public int Pagina { get; set; } = 1;
    public int TamañoPagina { get; set; } = 10;
}
