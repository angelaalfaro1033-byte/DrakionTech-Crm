using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GoogleEventoConfiguration : IEntityTypeConfiguration<GoogleEvento>
{
    public void Configure(EntityTypeBuilder<GoogleEvento> builder)
    {
        builder.ToTable("GoogleEventos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .HasMaxLength(250);

        builder.Property(x => x.Descripcion)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Ubicacion)
            .HasMaxLength(250);

        builder.Property(x => x.GoogleEventId)
            .HasMaxLength(200);

        builder.HasIndex(x => x.GoogleEventId)
            .IsUnique();
    }
}