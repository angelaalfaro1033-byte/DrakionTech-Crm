using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrakionTech.Crm.Data.Configurations
{
    public class EmpleadoSalarioConfiguration : IEntityTypeConfiguration<EmpleadoSalario>
    {
        public void Configure(EntityTypeBuilder<EmpleadoSalario> builder)
        {
            builder.ToTable("EmpleadoSalarios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Salario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.FechaRegistro)
                .IsRequired();

            builder.HasOne(x => x.Empleado)
                .WithOne(e => e.Salario)
                .HasForeignKey<EmpleadoSalario>(x => x.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}