using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Apellido).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Telefono).HasMaxLength(20);
        builder.Property(u => u.PasswordHash).HasMaxLength(500);
        builder.Property(u => u.ActivationToken).HasMaxLength(500);

        builder.HasOne(u => u.Rol)
            .WithMany()
            .HasForeignKey(u => u.RolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}