using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class UsuarioInternoConfiguration : IEntityTypeConfiguration<UsuarioInterno>
    {
        public void Configure(EntityTypeBuilder<UsuarioInterno> builder)
        {
            builder.ToTable("UsuarioInterno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Apellido)
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .HasMaxLength(200);

            builder.Property(x => x.Telefono)
                .HasMaxLength(50);

            builder.Property(x => x.IdentityUserId)
                .HasMaxLength(100);

            builder.Property(x => x.Activo)
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.Activo);
        }
    }
}