using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrakionTech.Crm.Data.Entities;

public class PagoProyecto
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }
    public Proyecto Proyecto { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Valor { get; set; }

    public DateTime FechaProgramada { get; set; }
    public DateTime? FechaPago { get; set; }
    public EstadoPagoProyecto Estado { get; set; } = EstadoPagoProyecto.Pendiente;

    public int? DiasAnticipacionRecordatorio { get; set; }
    public string? DescripcionRecordatorio { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaUltimaModificacion { get; set; }
}
