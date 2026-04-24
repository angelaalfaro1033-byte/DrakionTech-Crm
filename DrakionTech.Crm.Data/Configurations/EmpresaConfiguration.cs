using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas", t =>
            {
                t.HasCheckConstraint(
                    "CK_Empresas_Sector",
                    @"(
                        (SectorId IS NOT NULL AND SectorOtro IS NULL)
                        OR
                        (SectorId IS NULL AND LTRIM(RTRIM(SectorOtro)) <> '')
                    )"
                );

                t.HasCheckConstraint(
                    "CK_Empresas_Estado",
                    @"(
                        (EstadoId IS NOT NULL AND EstadoOtro IS NULL)
                        OR
                        (EstadoId IS NULL AND LTRIM(RTRIM(EstadoOtro)) <> '')
                    )"
                );
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Nit)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(e => e.Nit)
                .IsUnique();

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.PaisId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(e => e.Ciudad)
                .WithMany()
                .HasForeignKey(e => e.CiudadId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(e => e.Sector)
                .WithMany()
                .HasForeignKey(e => e.SectorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.Property(e => e.SectorOtro)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.HasOne(e => e.Estado)
            .WithMany()
            .HasForeignKey(e => e.EstadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

            builder.Property(e => e.EstadoOtro)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(e => e.FechaCreacion)
                .ValueGeneratedOnAdd();

            // Relaciones
            builder.HasMany(e => e.Contactos)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Oportunidades)
                .WithOne(o => o.Empresa)
                .HasForeignKey(o => o.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Actividades)
                .WithOne(a => a.Empresa)
                .HasForeignKey(a => a.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}