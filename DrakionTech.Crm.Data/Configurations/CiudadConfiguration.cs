using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudades");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.HasOne(c => c.Pais)
                  .WithMany(p => p.Ciudades)
                  .HasForeignKey(c => c.PaisId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}