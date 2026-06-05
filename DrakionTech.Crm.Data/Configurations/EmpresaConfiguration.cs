using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(e => e.Id);

            // Identificación
            builder.Property(e => e.TipoCliente).IsRequired();
            builder.Property(e => e.TipoDocumento).IsRequired();
            builder.Property(e => e.NumeroDocumento).IsRequired().HasMaxLength(30);

            // Datos generales
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Direccion).HasMaxLength(300);
            builder.Property(e => e.Telefono).HasMaxLength(30);
            builder.Property(e => e.PrefijoTelefonicoCodigo).HasMaxLength(10);
            builder.Property(e => e.Correo).HasMaxLength(200);
            builder.Property(e => e.RepresentanteLegal).HasMaxLength(200);

            // Clasificación
            builder.Property(e => e.Tamaño);
            builder.Property(e => e.Descripcion).HasMaxLength(1000);
            builder.Property(e => e.Seguimiento).HasMaxLength(2000);

            // Relaciones
            builder.HasOne(e => e.Pais)
                   .WithMany()
                   .HasForeignKey(e => e.PaisId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Ciudad)
                   .WithMany()
                   .HasForeignKey(e => e.CiudadId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SectorEmpresa)
                   .WithMany(s => s.Empresas)
                   .HasForeignKey(e => e.SectorEmpresaId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.SubsectorEmpresa)
                   .WithMany(s => s.Empresas)
                   .HasForeignKey(e => e.SubsectorEmpresaId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}