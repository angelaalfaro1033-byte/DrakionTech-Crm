using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EmpresaCorreoConfiguration : IEntityTypeConfiguration<EmpresaCorreo>
    {
        public void Configure(EntityTypeBuilder<EmpresaCorreo> builder)
        {
            builder.ToTable("EmpresaCorreos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Correo).IsRequired().HasMaxLength(200);
            builder.HasOne(e => e.Empresa)
                   .WithMany(emp => emp.Correos)
                   .HasForeignKey(e => e.EmpresaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}