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
            builder.ToTable("ActividadUsuarios");

            builder.HasKey(x => new
            {
                x.ActividadId,
                x.UsuarioInternoId
            });

            builder.HasOne(x => x.Actividad)
                .WithMany(a => a.UsuariosAsignados)
                .HasForeignKey(x => x.ActividadId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UsuarioInterno)
                .WithMany(u => u.ActividadesAsignadas)
                .HasForeignKey(x => x.UsuarioInternoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.UsuarioInternoId);

            builder.Property(x => x.EsResponsable)
                .IsRequired();
        }
    }
}