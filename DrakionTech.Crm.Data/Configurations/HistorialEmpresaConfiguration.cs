using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations;

public class HistorialEmpresaConfiguration : IEntityTypeConfiguration<HistorialEmpresa>
{
    public void Configure(EntityTypeBuilder<HistorialEmpresa> builder)
    {
        builder.ToTable("HistorialEmpresas");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.TipoEvento)
            .IsRequired();

        builder.Property(h => h.TituloEvento)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(h => h.DescripcionEvento)
            .HasMaxLength(2000);

        builder.Property(h => h.FechaEvento)
            .IsRequired();

        builder.Property(h => h.UsuarioResponsableNombre)
            .HasMaxLength(200);

        builder.Property(h => h.ModuloOrigen)
            .IsRequired();

        builder.Property(h => h.DatosAdicionales)
            .HasColumnType("nvarchar(max)");

        builder.Property(h => h.ClaveEvento)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasOne(h => h.Empresa)
            .WithMany(e => e.HistorialesEmpresa)
            .HasForeignKey(h => h.EmpresaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(h => h.UsuarioResponsable)
            .WithMany()
            .HasForeignKey(h => h.UsuarioResponsableId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.HasIndex(h => new { h.EmpresaId, h.FechaEvento });
        builder.HasIndex(h => new { h.EmpresaId, h.TipoEvento, h.FechaEvento });
        builder.HasIndex(h => new { h.EmpresaId, h.ModuloOrigen, h.FechaEvento });
        builder.HasIndex(h => h.ClaveEvento).IsUnique();
    }
}
