using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class PrefijoTelefonicoConfiguration : IEntityTypeConfiguration<PrefijoTelefonico>
    {
        public void Configure(EntityTypeBuilder<PrefijoTelefonico> builder)
        {
            builder.ToTable("PrefijosTelefonicos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(x => x.Pais)
                .WithMany(x => x.PrefijosTelefonicos)
                .HasForeignKey(x => x.PaisId);
        }
    }
}