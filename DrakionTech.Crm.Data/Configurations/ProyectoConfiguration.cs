using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
{
    public void Configure(EntityTypeBuilder<Proyecto> builder)
    {
        builder.ToTable("Proyectos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombre)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.Descripcion)
               .HasMaxLength(500);

        builder.Property(p => p.Estado)
               .IsRequired()
               .HasConversion<string>();

        builder.Property(p => p.FechaInicio)
               .IsRequired();

        builder.HasOne(p => p.Area)
               .WithMany()
               .HasForeignKey(p => p.AreaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Responsable)
               .WithMany()
               .HasForeignKey(p => p.ResponsableId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Oportunidad)
               .WithMany(o => o.Proyectos)
               .HasForeignKey(p => p.OportunidadId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}