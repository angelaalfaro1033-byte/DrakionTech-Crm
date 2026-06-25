namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class CrearAsignacionProyectoDto
{
    public int EmpleadoId { get; set; }
    public int ProyectoId { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
}
