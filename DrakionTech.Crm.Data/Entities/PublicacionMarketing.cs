using DrakionTech.Crm.Data.Entities.Base;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities;

public class PublicacionMarketing : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;

    public string? DescripcionCampania { get; set; }

    public string CopyUtilizado { get; set; } = string.Empty;

    public string? Observaciones { get; set; }

    public int ResponsableId { get; set; }

    public Usuario Responsable { get; set; } = null!;

    public DateTime FechaPublicacionProgramada { get; set; }

    public DateTime? FechaPublicacionReal { get; set; }

    public bool EnvioAutomatico { get; set; }

    public EstadoPublicacionMarketing Estado { get; set; }
        = EstadoPublicacionMarketing.Borrador;

    public bool Recordatorio3DiasEnviado { get; set; }

    public bool RecordatorioDiaPublicacionEnviado { get; set; }

    public bool AlertaRetrasoEnviada { get; set; }

    public ICollection<PublicacionRedSocial> RedesSociales { get; set; }
        = new List<PublicacionRedSocial>();

    public ICollection<MetricaPublicacion> Metricas { get; set; }
        = new List<MetricaPublicacion>();

    public ICollection<ArchivoPublicacionMarketing> Archivos { get; set; }
        = new List<ArchivoPublicacionMarketing>();

}