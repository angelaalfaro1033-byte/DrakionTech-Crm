using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class PagoProyectoConfiguration : IEntityTypeConfiguration<PagoProyecto>
{
    public void Configure(EntityTypeBuilder<PagoProyecto> builder)
    {
        builder.ToTable("PagosProyecto");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.FechaProgramada)
            .IsRequired();

        builder.Property(p => p.Estado)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.DescripcionRecordatorio)
            .HasMaxLength(500);

        builder.HasOne(p => p.Proyecto)
            .WithMany(p => p.Pagos)
            .HasForeignKey(p => p.ProyectoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
