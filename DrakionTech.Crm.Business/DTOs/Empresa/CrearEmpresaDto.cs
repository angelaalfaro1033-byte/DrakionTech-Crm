using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class CrearEmpresaDto : IEmpresaCatalogoDto
    {
        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Nit { get; set; } = null!;

        [Required]
        public string Direccion { get; set; } = null!;

        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string? Correo { get; set; }

        [Required]
        public int PaisId { get; set; }

        [Required]
        public int CiudadId { get; set; }

        public int? SectorId { get; set; }
        public string? SectorOtro { get; set; }

        public int? EstadoId { get; set; }
        public string? EstadoOtro { get; set; }

        public string? RepresentanteLegal { get; set; }
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }
        public string? Telefono { get; set; }

        [Required]
        public DateTime FechaVinculacion { get; set; }

        public bool HaTrabajadoAntes { get; set; }
        public DateTime? FechaEspecial { get; set; }
    }
}