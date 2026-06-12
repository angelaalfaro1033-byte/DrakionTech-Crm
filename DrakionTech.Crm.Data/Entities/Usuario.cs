namespace DrakionTech.Crm.Data.Entities;

public class Usuario : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
    public int RolId { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaModificacion { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsActive { get; set; } = false;
    public string? ActivationToken { get; set; }
    public DateTime? ActivationTokenExpiration { get; set; }
    public RolUsuario Rol { get; set; } = null!;
    public int? AreaId { get; set; }
    public virtual Area? Area { get; set; }
}
