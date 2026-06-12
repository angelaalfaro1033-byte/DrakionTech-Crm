using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class MetricaPublicacionConfiguration : IEntityTypeConfiguration<MetricaPublicacion>
{
    public void Configure(EntityTypeBuilder<MetricaPublicacion> builder)
    {
        builder.ToTable("MetricasPublicacion");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Observaciones)
            .HasMaxLength(2000);

        builder.Property(x => x.RedSocial)
            .HasConversion<int>();
    }
}