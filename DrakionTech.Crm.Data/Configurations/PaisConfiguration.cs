using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(p => p.CodigoIso)
                  .IsRequired()
                  .HasMaxLength(5);
        }
    }
}