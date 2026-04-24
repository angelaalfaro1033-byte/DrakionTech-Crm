using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EstadoActividadConfiguration
        : IEntityTypeConfiguration<EstadoActividad>
    {
        public void Configure(EntityTypeBuilder<EstadoActividad> builder)
        {
            builder.ToTable("EstadoActividad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Activo)
                .IsRequired();

            builder.HasIndex(e => e.Nombre);
        }
    }
}