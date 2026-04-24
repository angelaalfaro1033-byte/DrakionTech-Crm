using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class TipoActividadConfiguration
        : IEntityTypeConfiguration<TipoActividad>
    {
        public void Configure(EntityTypeBuilder<TipoActividad> builder)
        {
            builder.ToTable("TipoActividad");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(t => t.Descripcion)
                .HasMaxLength(500);

            builder.Property(t => t.Activo)
                .IsRequired();

            builder.HasIndex(t => t.Nombre)
                .IsUnique(false);
        }
    }
}