using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class ActividadConfiguration : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable("Actividades");

            builder.HasKey(a => a.Id);

            // CATÁLOGOS

            builder.Property(a => a.TipoActividadId)
                .IsRequired();

            builder.Property(a => a.EstadoActividadId)
                .IsRequired();

            builder.HasOne(a => a.TipoActividad)
                .WithMany(t => t.Actividades)
                .HasForeignKey(a => a.TipoActividadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.EstadoActividad)
                .WithMany(t => t.Actividades)
                .HasForeignKey(a => a.EstadoActividadId)
                .OnDelete(DeleteBehavior.Restrict);

            // AGENDA 

            builder.Property(a => a.Inicio)
                .IsRequired();

            builder.Property(a => a.Fin)
                .IsRequired(false);

            // RESPONSABLE

            builder.Property(a => a.UsuarioInternoId)
                .IsRequired();

            builder.HasOne(a => a.UsuarioInterno)
                .WithMany(t => t.ActividadesResponsable)
                .HasForeignKey(a => a.UsuarioInternoId)
                .OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DE TEXTO

            builder.Property(a => a.Resultado)
                .HasMaxLength(1000);

            builder.Property(a => a.Notas)
                .HasMaxLength(2000);

            builder.Property(a => a.ExternalCalendarEventId)
                .HasMaxLength(200);

            // RELACIONES 

            builder.HasOne(a => a.Empresa)
                .WithMany(e => e.Actividades)
                .HasForeignKey(a => a.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Contacto)
                .WithMany()
                .HasForeignKey(a => a.ContactoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Oportunidad)
                .WithMany()
                .HasForeignKey(a => a.OportunidadId)
                .OnDelete(DeleteBehavior.Restrict);

            // FECHA CREACIÓN 

            builder.Property(a => a.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // ÍNDICES (CONSULTAS Y CALENDARIO)

            // FK - catálogos
            builder.HasIndex(a => a.TipoActividadId);
            builder.HasIndex(a => a.EstadoActividadId);

            // FK - relaciones CRM
            builder.HasIndex(a => a.EmpresaId);
            builder.HasIndex(a => a.ContactoId);
            builder.HasIndex(a => a.OportunidadId);

            // Agenda
            builder.HasIndex(a => a.UsuarioInternoId);
            builder.HasIndex(a => a.Inicio);

            builder.HasIndex(a => new
            {
                a.UsuarioInternoId,
                a.Inicio,
                a.Fin
            });
        }
    }
}