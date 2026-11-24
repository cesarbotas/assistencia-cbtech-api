using CBTech.Domain.Entities.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Fornecedores;

public class EnderecoFornecedorConfiguration : IEntityTypeConfiguration<EnderecoFornecedor>
{
    public void Configure(EntityTypeBuilder<EnderecoFornecedor> b)
    {
        b.ToTable("EnderecosFornecedores");

        b.HasKey(x => x.Id);

        b.Property(x => x.Logradouro)
            .HasMaxLength(200)
            .IsRequired();

        b.Property(x => x.Numero)
            .HasMaxLength(20)
            .IsRequired();

        b.Property(x => x.Complemento)
            .HasMaxLength(100);

        b.Property(x => x.Bairro)
            .HasMaxLength(100)
            .IsRequired();

        b.Property(x => x.Cidade)
            .HasMaxLength(100)
            .IsRequired();

        b.Property(x => x.Estado)
            .HasMaxLength(2)
            .IsRequired();

        b.Property(x => x.Cep)
            .HasMaxLength(8)
            .IsRequired();
    }
}
