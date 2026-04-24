using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class PropuestaConfiguration : IEntityTypeConfiguration<Propuesta>
    {
        public void Configure(EntityTypeBuilder<Propuesta> builder)
        {
            builder.ToTable("Propuestas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NombreArchivo)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.RutaArchivo)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.TipoContenido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.TamanoArchivo)
                .IsRequired();

            builder.Property(p => p.FechaCarga)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}