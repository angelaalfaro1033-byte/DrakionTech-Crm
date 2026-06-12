using DrakionTech.Crm.Data.Entities.Base;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrakionTech.Crm.Data.Entities;

public class PublicacionRedSocial : BaseEntity
{
    public int PublicacionMarketingId { get; set; }

    public PublicacionMarketing PublicacionMarketing { get; set; } = null!;

    public RedSocial RedSocial { get; set; }

    public bool TienePauta { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CostoPauta { get; set; }

    public int? DiasPauta { get; set; }
}