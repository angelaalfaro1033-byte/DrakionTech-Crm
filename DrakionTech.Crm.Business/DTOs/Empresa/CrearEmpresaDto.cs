using DrakionTech.Crm.Business.Common;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class CrearEmpresaDto : IEmpresaCatalogoDto
    {
        [Required(ErrorMessage = MensajesError.NombreEmpresaObligatorio)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.NitObligatorio)]
        public string Nit { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.DireccionObligatorio)]
        public string Direccion { get; set; } = null!;

        [EmailAddress(ErrorMessage = MensajesError.EmailInvalidoFormato)]
        public string? Correo { get; set; }

        [Required(ErrorMessage = MensajesError.PaisObligatorio)]
        public int PaisId { get; set; }

        [Required(ErrorMessage = MensajesError.CiudadObligatorio)]
        public int CiudadId { get; set; }

        public int? SectorId { get; set; }
        public string? SectorOtro { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoOtro { get; set; }
        public string? RepresentanteLegal { get; set; }
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }
        public string? Telefono { get; set; }

        [Required(ErrorMessage = MensajesError.FechaVinculacionObligatoria)]
        public DateTime FechaVinculacion { get; set; }

        public bool HaTrabajadoAntes { get; set; }
        public DateTime? FechaEspecial { get; set; }
    }
}