namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class ActualizarAsignacionProyectoDto
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
}
