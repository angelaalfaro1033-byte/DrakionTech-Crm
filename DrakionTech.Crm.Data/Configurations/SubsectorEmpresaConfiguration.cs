using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class SubsectorEmpresaConfiguration : IEntityTypeConfiguration<SubsectorEmpresa>
    {
        public void Configure(EntityTypeBuilder<SubsectorEmpresa> builder)
        {
            builder.ToTable("SubsectoresEmpresa");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}