using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class PublicacionRedSocialConfiguration : IEntityTypeConfiguration<PublicacionRedSocial>
{
    public void Configure(EntityTypeBuilder<PublicacionRedSocial> builder)
    {
        builder.ToTable("PublicacionRedesSociales");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RedSocial)
            .HasConversion<int>();

        builder.Property(x => x.CostoPauta)
            .HasColumnType("decimal(18,2)");

        // Evita duplicar la misma red social para una publicación
        builder.HasIndex(x => new
        {
            x.PublicacionMarketingId,
            x.RedSocial
        }).IsUnique();
    }
}