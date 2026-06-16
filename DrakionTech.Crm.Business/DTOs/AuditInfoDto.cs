namespace DrakionTech.Crm.Business.DTOs;

public class AuditInfoDto
{
    public int? CreatedByUserId { get; set; }
    public string? CreatedByUserName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? ModifiedByUserId { get; set; }
    public string? ModifiedByUserName { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public string LastUpdatedByName => !string.IsNullOrWhiteSpace(ModifiedByUserName)
        ? ModifiedByUserName!
        : CreatedByUserName ?? "Sin usuario registrado";

    public DateTime? LastUpdatedAt => ModifiedAt ?? CreatedAt;
}
