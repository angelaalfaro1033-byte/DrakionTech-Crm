using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable("Contactos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .HasMaxLength(320);

            builder.Property(c => c.RolContactoId)
                .IsRequired()
                .HasDefaultValue(SeedIds.RolContactoDesconocido);

            builder.HasOne(c => c.RolContacto)
                .WithMany()
                .HasForeignKey(c => c.RolContactoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.FechaVinculacion)
                .IsRequired(false);

            builder.Property(c => c.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Contactos)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}