using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class PublicacionMarketingConfiguration : IEntityTypeConfiguration<PublicacionMarketing>
{
    public void Configure(EntityTypeBuilder<PublicacionMarketing> builder)
    {
        builder.ToTable("PublicacionesMarketing");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.DescripcionCampania)
            .HasMaxLength(1000);

        builder.Property(x => x.CopyUtilizado)
            .IsRequired()
            .HasMaxLength(5000);

        builder.Property(x => x.Estado)
            .HasConversion<int>();

        builder.HasMany(x => x.Archivos)
            .WithOne(x => x.PublicacionMarketing)
            .HasForeignKey(x => x.PublicacionMarketingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Observaciones)
            .HasMaxLength(2000);

        builder.HasOne(x => x.Responsable)
            .WithMany()
            .HasForeignKey(x => x.ResponsableId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.RedesSociales)
            .WithOne(x => x.PublicacionMarketing)
            .HasForeignKey(x => x.PublicacionMarketingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Metricas)
            .WithOne(x => x.PublicacionMarketing)
            .HasForeignKey(x => x.PublicacionMarketingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}