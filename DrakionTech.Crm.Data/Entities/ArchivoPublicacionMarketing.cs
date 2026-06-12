using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities;

public class ArchivoPublicacionMarketing : BaseEntity
{
    public int PublicacionMarketingId { get; set; }

    public PublicacionMarketing PublicacionMarketing { get; set; } = null!;

    public string Nombre { get; set; } = string.Empty;

    public string ArchivoIdExterno { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string MimeType { get; set; } = string.Empty;
}