using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class OportunidadConfiguration : IEntityTypeConfiguration<Oportunidad>
    {
        public void Configure(EntityTypeBuilder<Oportunidad> builder)
        {
            builder.ToTable("Oportunidades");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.NombreProyecto)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(o => o.ValorEstimado)
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Etapa)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(o => o.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(o => o.Empresa)
                .WithMany(e => e.Oportunidades)
                .HasForeignKey(o => o.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ContactoPrincipal)
                .WithMany()
                .HasForeignKey(o => o.ContactoPrincipalId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(o => o.Propuestas)
                .WithOne(p => p.Oportunidad)
                .HasForeignKey(p => p.OportunidadId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}