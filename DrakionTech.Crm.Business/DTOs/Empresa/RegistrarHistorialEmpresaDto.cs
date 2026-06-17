using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Empresa;

public class RegistrarHistorialEmpresaDto
{
    public int EmpresaId { get; set; }
    public TipoEventoHistorialEmpresa TipoEvento { get; set; }
    public string TituloEvento { get; set; } = string.Empty;
    public string? DescripcionEvento { get; set; }
    public DateTime? FechaEvento { get; set; }
    public int? UsuarioResponsableId { get; set; }
    public string? UsuarioResponsableNombre { get; set; }
    public ModuloOrigenHistorialEmpresa ModuloOrigen { get; set; }
    public int? RegistroOrigenId { get; set; }
    public string? DatosAdicionales { get; set; }
    public string? ClaveEvento { get; set; }
}
