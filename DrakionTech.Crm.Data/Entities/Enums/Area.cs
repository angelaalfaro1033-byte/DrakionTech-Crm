namespace DrakionTech.Crm.Data.Entities;

/// <summary>Entidad que representa un área organizacional.</summary>
public class Area : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
{
    public int Id { get; set; }

    /// <summary>Nombre del área. Único, almacenado en su forma original; comparación siempre case-insensitive.</summary>
    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public bool Activa { get; set; } = true;

    public int? ResponsableId { get; set; }
    public virtual Usuario? Responsable { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaModificacion { get; set; }

    // Navegación: usuarios que pertenecen a esta área
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
