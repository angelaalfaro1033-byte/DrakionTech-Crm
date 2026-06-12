using DrakionTech.Crm.Data.Entities;

public class ActividadUsuario : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
{
    public int ActividadId { get; set; }
    public Actividad Actividad { get; set; } = null!;
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public bool EsResponsable { get; set; }
}
