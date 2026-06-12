using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class ArchivoPublicacionMarketingConfiguration
    : IEntityTypeConfiguration<ArchivoPublicacionMarketing>
{
    public void Configure(EntityTypeBuilder<ArchivoPublicacionMarketing> builder)
    {
        builder.ToTable("ArchivosPublicacionMarketing");

        builder.Property(x => x.Nombre)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.ArchivoIdExterno)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(1000);

        builder.Property(x => x.MimeType)
            .HasMaxLength(150);

        builder.HasOne(x => x.PublicacionMarketing)
            .WithMany(x => x.Archivos)
            .HasForeignKey(x => x.PublicacionMarketingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}