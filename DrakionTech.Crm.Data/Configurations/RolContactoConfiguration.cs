using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class RolContactoConfiguration : IEntityTypeConfiguration<RolContacto>
    {
        public void Configure(EntityTypeBuilder<RolContacto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RolContacto { Id = SeedIds.RolContactoDesconocido, Nombre = "Desconocido" },
                new RolContacto { Id = SeedIds.RolContactoCEO, Nombre = "CEO" },
                new RolContacto { Id = SeedIds.RolContactoCTO, Nombre = "CTO" },
                new RolContacto { Id = SeedIds.RolContactoCFO, Nombre = "CFO" },
                new RolContacto { Id = SeedIds.RolContactoCOO, Nombre = "COO" },
                new RolContacto { Id = SeedIds.RolContactoDirector, Nombre = "Director" },
                new RolContacto { Id = SeedIds.RolContactoGerente, Nombre = "Gerente" },
                new RolContacto { Id = SeedIds.RolContactoProjectManager, Nombre = "Project Manager" },
                new RolContacto { Id = SeedIds.RolContactoLiderTecnico, Nombre = "Líder Técnico" },
                new RolContacto { Id = SeedIds.RolContactoRecursosHumanos, Nombre = "Recursos Humanos" },
                new RolContacto { Id = SeedIds.RolContactoCompras, Nombre = "Compras" },
                new RolContacto { Id = SeedIds.RolContactoVentas, Nombre = "Ventas" },
                new RolContacto { Id = SeedIds.RolContactoMarketing, Nombre = "Marketing" },
                new RolContacto { Id = SeedIds.RolContactoOtro, Nombre = "Otro" }
            );
        }
    }
}