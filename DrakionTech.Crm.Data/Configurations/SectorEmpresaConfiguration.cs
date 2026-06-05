using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class SectorEmpresaConfiguration : IEntityTypeConfiguration<SectorEmpresa>
    {
        public void Configure(EntityTypeBuilder<SectorEmpresa> builder)
        {
            builder.ToTable("SectoresEmpresa");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nombre).IsRequired().HasMaxLength(100);

            builder.HasMany(s => s.Subsectores)
                   .WithMany(sub => sub.Sectores)
                   .UsingEntity(j => j.ToTable("SectorSubsector"));

            builder.HasData(
                new SectorEmpresa { Id = 1, Nombre = "Primario" },
                new SectorEmpresa { Id = 2, Nombre = "Manufactura" },
                new SectorEmpresa { Id = 3, Nombre = "Comercio" },
                new SectorEmpresa { Id = 4, Nombre = "Servicios" }
            );
        }
    }
}