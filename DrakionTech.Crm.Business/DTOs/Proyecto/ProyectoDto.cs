using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class ProyectoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoProyecto Estado { get; set; }
    public string EstadoTexto => Estado switch
    {
        EstadoProyecto.Planificado => "Planificado",
        EstadoProyecto.Ejecutándose => "Ejecutándose",
        EstadoProyecto.Completado => "Completado",
        EstadoProyecto.Cancelado => "Cancelado",
        _ => Estado.ToString()
    };
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int AreaId { get; set; }          // ← agrega
    public string AreaNombre { get; set; } = string.Empty;

    public int ResponsableId { get; set; }   // ← agrega
    public string ResponsableNombre { get; set; } = string.Empty;
}