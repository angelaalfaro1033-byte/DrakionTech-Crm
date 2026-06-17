using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Empresa;

public class HistorialEmpresaDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }

    public TipoEventoHistorialEmpresa TipoEvento { get; set; }
    public string TipoEventoNombre => TipoEvento.ToString();

    public string TituloEvento { get; set; } = string.Empty;
    public string? DescripcionEvento { get; set; }
    public DateTime FechaEvento { get; set; }

    public int? UsuarioResponsableId { get; set; }
    public string UsuarioResponsableNombre { get; set; } = "Sin usuario registrado";

    public ModuloOrigenHistorialEmpresa ModuloOrigen { get; set; }
    public string ModuloOrigenNombre => ModuloOrigen.ToString();

    public int? RegistroOrigenId { get; set; }
    public string? DatosAdicionales { get; set; }
}
