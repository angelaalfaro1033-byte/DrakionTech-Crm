using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities
{
    public class Empresa : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
    {
        public int Id { get; set; }

        public TipoCliente TipoCliente { get; set; } = TipoCliente.Juridico;
        public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.NIT;
        public string NumeroDocumento { get; set; } = null!;

        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; } = null!;

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; } = null!;

        public string? Telefono { get; set; }
        public int? PrefijoTelefonicoId { get; set; }
        public string? PrefijoTelefonicoCodigo { get; set; }

        public string? Correo { get; set; }

        public string? RepresentanteLegal { get; set; }

        public DateTime? FechaCreacionEmpresa { get; set; }
        public DateTime FechaRegistroCrm { get; set; } = DateTime.UtcNow;

        public TamañoEmpresa? Tamaño { get; set; }

        public int? SectorEmpresaId { get; set; }
        public SectorEmpresa? SectorEmpresa { get; set; }

        public int? SubsectorEmpresaId { get; set; }
        public SubsectorEmpresa? SubsectorEmpresa { get; set; }

        public string? Descripcion { get; set; }
        public string? Seguimiento { get; set; }

        public bool Activa { get; set; } = false;
        public bool HaTrabajadoAntes { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
        public ICollection<EmpresaCorreo> Correos { get; set; } = new List<EmpresaCorreo>();
        public ICollection<Oportunidad> Oportunidades { get; set; } = new List<Oportunidad>();
        public ICollection<Actividad> Actividades { get; set; } = new List<Actividad>();
        public ICollection<HistorialEmpresa> HistorialesEmpresa { get; set; } = new List<HistorialEmpresa>();
    }
}
