using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities;

public class Proyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoProyecto Estado { get; set; } = EstadoProyecto.Planificado;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int AreaId { get; set; }
    public Area Area { get; set; } = null!;

    public int ResponsableId { get; set; }
    public Usuario Responsable { get; set; } = null!;

    public int? OportunidadId { get; set; }
    public Oportunidad? Oportunidad { get; set; }
}