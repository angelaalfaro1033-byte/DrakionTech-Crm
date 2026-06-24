using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class EmpleadoProyectoAsignacionConfiguration : IEntityTypeConfiguration<EmpleadoProyectoAsignacion>
{
    public void Configure(EntityTypeBuilder<EmpleadoProyectoAsignacion> builder)
    {
        builder.ToTable("EmpleadoProyectoAsignaciones");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.FechaInicio)
            .IsRequired();

        builder.Property(a => a.Activa)
            .HasDefaultValue(true);

        builder.Property(a => a.RolEnProyecto)
            .HasMaxLength(100);

        builder.Property(a => a.Observaciones)
            .HasMaxLength(500);

        builder.HasOne(a => a.Empleado)
            .WithMany(e => e.AsignacionesProyecto)
            .HasForeignKey(a => a.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Proyecto)
            .WithMany(p => p.AsignacionesEmpleado)
            .HasForeignKey(a => a.ProyectoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => new { a.EmpleadoId, a.ProyectoId })
            .HasDatabaseName("IX_EmpleadoProyectoAsignaciones_Empleado_Proyecto");

        builder.HasIndex(a => new { a.ProyectoId, a.Activa })
            .HasDatabaseName("IX_EmpleadoProyectoAsignaciones_Proyecto_Activa");

        builder.HasIndex(a => new { a.EmpleadoId, a.Activa })
            .HasDatabaseName("IX_EmpleadoProyectoAsignaciones_Empleado_Activa");

        builder.HasIndex(a => new { a.EmpleadoId, a.ProyectoId, a.Activa })
            .IsUnique()
            .HasFilter("[Activa] = 1")
            .HasDatabaseName("UX_EmpleadoProyectoAsignaciones_Activa");
    }
}
