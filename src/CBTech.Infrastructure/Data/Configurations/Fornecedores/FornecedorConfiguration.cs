using CBTech.Domain.Entities.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Fornecedores;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.RazaoSocial).HasMaxLength(200).IsRequired();
        b.Property(x => x.NomeFantasia).HasMaxLength(100).IsRequired();
        b.Property(x => x.Cnpj).HasMaxLength(14);
        b.Property(x => x.Contato).HasMaxLength(100);
        b.Property(x => x.Telefone).HasMaxLength(20);
        b.Property(x => x.Whatsapp).HasMaxLength(20);
        b.Property(x => x.Email).HasMaxLength(200);
        b.Property(x => x.CondicaoPagamento).HasMaxLength(200);
        b.Property(x => x.PrazoEntregaDias).IsRequired();
        b.Property(x => x.Ativo).IsRequired();
        b.Property(x => x.CriadoEm).IsRequired();
        b.Property(x => x.AtualizadoEm);

        b.HasOne(x => x.Endereco)
            .WithOne()
            .HasForeignKey<EnderecoFornecedor>(e => e.FornecedorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
