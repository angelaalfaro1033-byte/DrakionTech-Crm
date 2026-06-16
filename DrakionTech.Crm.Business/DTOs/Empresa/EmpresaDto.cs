using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class EmpresaDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
    {
        public int Id { get; set; }

        public TipoCliente TipoCliente { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;

        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }

        public int PaisId { get; set; }
        public string PaisNombre { get; set; } = string.Empty;

        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; } = string.Empty;

        public string? Telefono { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }
        public int? PrefijoTelefonicoId { get; set; }

        [EmailAddress(ErrorMessage = MensajesError.EmailInvalidoFormato)]
        public string? Correo { get; set; }

        public string? RepresentanteLegal { get; set; }

        public DateTime? FechaCreacionEmpresa { get; set; }
        public DateTime FechaRegistroCrm { get; set; }

        public int? SectorEmpresaId { get; set; }
        public string? SectorEmpresaNombre { get; set; }

        public int? SubsectorEmpresaId { get; set; }
        public string? SubsectorEmpresaNombre { get; set; }

        public TamañoEmpresa? Tamaño { get; set; }
        public string? Descripcion { get; set; }
        public string? Seguimiento { get; set; }

        public bool Activa { get; set; }
        public bool HaTrabajadoAntes { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<EmpresaCorreoDto> Correos { get; set; } = new();
        public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
    }
}
