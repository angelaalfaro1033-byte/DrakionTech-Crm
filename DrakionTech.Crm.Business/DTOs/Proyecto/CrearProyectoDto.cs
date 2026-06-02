using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class CrearProyectoDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descripcion { get; set; }

    public EstadoProyecto Estado { get; set; } = EstadoProyecto.Planificado;

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; } = DateTime.Today;

    public DateTime? FechaFin { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un área.")]
    public int AreaId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un responsable.")]
    public int ResponsableId { get; set; }

    public int? OportunidadId { get; set; }
}