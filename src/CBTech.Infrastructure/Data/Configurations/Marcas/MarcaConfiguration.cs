using CBTech.Domain.Entities.Marcas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Marcas;

public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("Marcas");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.Property(m => m.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(m => m.CriadoEm)
            .IsRequired();

        builder.Property(m => m.AtualizadoEm)
            .IsRequired();
    }
}
