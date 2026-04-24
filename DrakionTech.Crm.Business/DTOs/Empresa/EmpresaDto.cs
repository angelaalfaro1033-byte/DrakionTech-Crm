using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class EmpresaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string? Correo { get; set; }

        public int PaisId { get; set; }
        public string PaisNombre { get; set; } = string.Empty;

        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; } = string.Empty;

        public int? SectorId { get; set; }
        public string SectorNombre { get; set; } = string.Empty;
        public string? SectorOtro { get; set; }

        public int? EstadoId { get; set; }
        public string EstadoNombre { get; set; } = string.Empty;
        public string? EstadoOtro { get; set; }

        public string? RepresentanteLegal { get; set; }
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }
        public string? Telefono { get; set; }

        public DateTime FechaVinculacion { get; set; }
        public DateTime? FechaEspecial { get; set; }
    }
}