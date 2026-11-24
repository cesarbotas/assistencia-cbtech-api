using CBTech.Domain.Entities.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Categorias;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(categoria => categoria.Id);
        builder.Property(categoria => categoria.Id).ValueGeneratedNever();
        builder.Property(categoria => categoria.Nome).HasMaxLength(100).IsRequired();
        builder.Property(categoria => categoria.Descricao).HasMaxLength(200);
    }
}