namespace DrakionTech.Crm.Data.Entities;

public class EmpleadoProyectoAsignacion : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; } = null!;
    public int ProyectoId { get; set; }
    public Proyecto Proyecto { get; set; } = null!;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Activa { get; set; } = true;
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
}
