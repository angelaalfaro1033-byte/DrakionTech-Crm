using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class HistorialCambioOportunidadConfiguration
        : IEntityTypeConfiguration<HistorialCambioOportunidad>
    {
        public void Configure(EntityTypeBuilder<HistorialCambioOportunidad> builder)
        {
            builder.ToTable("HistorialCambiosOportunidad");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.EtapaAnterior)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(h => h.EtapaNueva)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(h => h.FechaCambio)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(h => h.Oportunidad)
                .WithMany(o => o.HistorialCambios)
                .HasForeignKey(h => h.OportunidadId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}