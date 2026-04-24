using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sectores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(s => s.Nombre)
                .IsUnique();
        }
    }
}