using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class PagoProyectoDto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor a cero.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "La fecha programada es obligatoria.")]
    public DateTime FechaProgramada { get; set; } = DateTime.Today;

    public DateTime? FechaPago { get; set; }
    public EstadoPagoProyecto Estado { get; set; } = EstadoPagoProyecto.Pendiente;

    [Range(0, 365, ErrorMessage = "Los días de anticipación deben estar entre 0 y 365.")]
    public int? DiasAnticipacionRecordatorio { get; set; }

    [MaxLength(500)]
    public string? DescripcionRecordatorio { get; set; }

    public DateTime? FechaRecordatorio =>
        DiasAnticipacionRecordatorio.HasValue
            ? FechaProgramada.Date.AddDays(-DiasAnticipacionRecordatorio.Value)
            : null;

    public bool TieneRecordatorioPendiente =>
        Estado == EstadoPagoProyecto.Pendiente && FechaRecordatorio.HasValue;

    public string EstadoTexto => Estado switch
    {
        EstadoPagoProyecto.Pendiente => "Pendiente",
        EstadoPagoProyecto.Pagado => "Pagado",
        EstadoPagoProyecto.Vencido => "Vencido",
        EstadoPagoProyecto.Cancelado => "Cancelado",
        _ => Estado.ToString()
    };

    public string RecordatorioTexto =>
        !FechaRecordatorio.HasValue
            ? "Sin recordatorio"
            : Estado == EstadoPagoProyecto.Pagado
                ? "Finalizado por pago registrado"
                : FechaRecordatorio.Value.ToShortDateString();
}
