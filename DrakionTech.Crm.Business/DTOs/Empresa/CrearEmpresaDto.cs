using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class CrearEmpresaDto : IEmpresaCatalogoDto
    {
        // Tipo cliente y documento
        [Required(ErrorMessage = "El tipo de cliente es obligatorio")]
        public TipoCliente TipoCliente { get; set; } = TipoCliente.Juridico;

        public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.NIT;

        [Required(ErrorMessage = MensajesError.NitObligatorio)]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.NombreEmpresaObligatorio)]
        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        [Required(ErrorMessage = MensajesError.PaisObligatorio)]
        public int PaisId { get; set; }

        [Required(ErrorMessage = MensajesError.CiudadObligatorio)]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; } = null!;
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }

        // Correo principal obligatorio + lista de correos adicionales
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = MensajesError.EmailInvalidoFormato)]
        public string Correo { get; set; } = null!;
        public List<EmpresaCorreoDto> Correos { get; set; } = new();

        // Contacto principal inline
        public ContactoPrincipalDto? ContactoPrincipal { get; set; }
        public List<ContactoAdicionalDto> ContactosAdicionales { get; set; } = new();

        // Fechas
        public DateTime? FechaCreacionEmpresa { get; set; }
        public DateTime FechaRegistroCrm { get; set; } = DateTime.Today;

        // Sector/Subsector nuevo
        [Required(ErrorMessage = "El sector es obligatorio")]
        public int? SectorEmpresaId { get; set; }
        public int? SubsectorEmpresaId { get; set; }

        // Tamaño
        [Required(ErrorMessage = "El tamaño de empresa es obligatorio")]
        public TamañoEmpresa? Tamaño { get; set; }

        // Descripción y seguimiento
        public string? Descripcion { get; set; }
        public string? Seguimiento { get; set; }

        // Legacy
        public string? RepresentanteLegal { get; set; }
        public bool HaTrabajadoAntes { get; set; }
    }
}