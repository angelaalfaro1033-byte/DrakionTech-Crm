using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities;

public class HistorialEmpresa
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }
    public Empresa Empresa { get; set; } = null!;

    public TipoEventoHistorialEmpresa TipoEvento { get; set; }

    public string TituloEvento { get; set; } = string.Empty;
    public string? DescripcionEvento { get; set; }
    public DateTime FechaEvento { get; set; } = DateTime.UtcNow;

    public int? UsuarioResponsableId { get; set; }
    public Usuario? UsuarioResponsable { get; set; }
    public string? UsuarioResponsableNombre { get; set; }

    public ModuloOrigenHistorialEmpresa ModuloOrigen { get; set; }
    public int? RegistroOrigenId { get; set; }

    public string? DatosAdicionales { get; set; }
    public string ClaveEvento { get; set; } = string.Empty;
}
