using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> entity)
        {
            entity.ToTable("Empleados");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TipoDocumento)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20);

            entity.HasIndex(e => e.NumeroDocumento)
                .IsUnique()
                .HasFilter("[NumeroDocumento] IS NOT NULL");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.Activo)
                .HasDefaultValue(true);

            entity.HasOne(e => e.RolUsuario)
                .WithMany()
                .HasForeignKey(e => e.RolUsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.EspecialidadNavigation)
                .WithMany()
                .HasForeignKey(e => e.EspecialidadId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}