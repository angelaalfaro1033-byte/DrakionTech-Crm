namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class AsignacionProyectoListDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public string EmpleadoNombre { get; set; } = string.Empty;
    public int ProyectoId { get; set; }
    public string ProyectoNombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Activa { get; set; }
    public string Estado => Activa ? "Activa" : "Finalizada";
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
    public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
}
