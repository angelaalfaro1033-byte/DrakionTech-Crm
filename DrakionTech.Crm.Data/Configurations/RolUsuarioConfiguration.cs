using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class RolUsuarioConfiguration : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RolUsuario { Id = SeedIds.RolUsuarioAdministrador, Nombre = "Administrador" },
                new RolUsuario { Id = SeedIds.RolUsuarioMarketing, Nombre = "Marketing" }
            );
        }
    }
}