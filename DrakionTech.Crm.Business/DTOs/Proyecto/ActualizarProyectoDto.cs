using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class ActualizarProyectoDto : CrearProyectoDto
{
    [Required]
    public int Id { get; set; }
}