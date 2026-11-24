using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Entities.Fornecedores;
using CBTech.Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Produtos;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(produto => produto.Id);
        builder.Property(produto => produto.Id).ValueGeneratedNever();
        builder.Property(produto => produto.Nome).HasMaxLength(200).IsRequired();
        builder.Property(produto => produto.Sku).HasMaxLength(50).IsRequired();
        builder.Property(produto => produto.CodigoBarras).HasMaxLength(50);
        builder.Property(produto => produto.PrecoCusto).HasPrecision(18, 2).IsRequired();
        builder.Property(produto => produto.PrecoVenda).HasPrecision(18, 2).IsRequired();
        builder.Property(produto => produto.EstoqueAtual).IsRequired();
        builder.Property(produto => produto.EstoqueMinimo).IsRequired();
        builder.Property(produto => produto.UnidadeMedida).HasMaxLength(10).IsRequired();
        builder.Property(produto => produto.Ativo).IsRequired();
        builder.Property(produto => produto.CriadoEm).IsRequired();
        builder.Property(produto => produto.AtualizadoEm).IsRequired();

        builder.HasIndex(produto => produto.Sku).IsUnique();
        builder.HasIndex(produto => produto.CodigoBarras).IsUnique();
        builder.HasIndex(produto => produto.CategoriaId);
        builder.HasIndex(produto => produto.FornecedorId);

        builder.HasOne<Categoria>(produto => produto.Categoria)
            .WithMany()
            .HasForeignKey(produto => produto.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Fornecedor>(produto => produto.Fornecedor)
            .WithMany()
            .HasForeignKey(produto => produto.FornecedorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}