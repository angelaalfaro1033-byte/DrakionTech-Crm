using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class ActualizarEmpresaDto : IEmpresaCatalogoDto
    {
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

        public string? Telefono { get; set; }
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }

        [EmailAddress(ErrorMessage = MensajesError.EmailInvalidoFormato)]
        public string? Correo { get; set; }

        public List<EmpresaCorreoDto> Correos { get; set; } = new();

        public ContactoPrincipalDto? ContactoPrincipal { get; set; }

        public string? RepresentanteLegal { get; set; }

        public DateTime? FechaCreacionEmpresa { get; set; }
        public DateTime FechaRegistroCrm { get; set; } = DateTime.Today;

        public int? SectorEmpresaId { get; set; }
        public int? SubsectorEmpresaId { get; set; }

        public TamañoEmpresa? Tamaño { get; set; }

        public string? Descripcion { get; set; }
        public string? Seguimiento { get; set; }

        public bool HaTrabajadoAntes { get; set; }
        public DateTime? FechaEspecial { get; set; }
    }
}