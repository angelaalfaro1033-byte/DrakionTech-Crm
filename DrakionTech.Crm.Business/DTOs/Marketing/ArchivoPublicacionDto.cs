using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class ArchivoPublicacionDto
{
    public string Nombre { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string ArchivoIdExterno { get; set; } = string.Empty;

    public string MimeType { get; set; } = string.Empty;
}