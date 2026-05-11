using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class ActividadUsuarioConfiguration
        : IEntityTypeConfiguration<ActividadUsuario>
    {
        public void Configure(EntityTypeBuilder<ActividadUsuario> builder)
        {
            builder.HasKey(x => new
            {
                x.ActividadId,
                x.UsuarioId
            });

            builder.HasOne(x => x.Actividad)
                .WithMany(a => a.UsuariosAsignados)
                .HasForeignKey(x => x.ActividadId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.UsuarioId);

            builder.Property(x => x.EsResponsable)
                .IsRequired();
        }
    }
}