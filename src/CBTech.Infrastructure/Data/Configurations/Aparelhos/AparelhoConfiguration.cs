using CBTech.Domain.Entities.Aparelhos;
using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Entities.Marcas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Aparelhos;

public class AparelhoConfiguration : IEntityTypeConfiguration<Aparelho>
{
    public void Configure(EntityTypeBuilder<Aparelho> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.ClienteId).IsRequired();
        b.Property(x => x.MarcaId).IsRequired();
        b.Property(x => x.Modelo).HasMaxLength(200).IsRequired();
        b.Property(x => x.Cor).HasMaxLength(50);
        b.Property(x => x.Imei1).HasMaxLength(17);
        b.Property(x => x.Imei2).HasMaxLength(17);
        b.Property(x => x.NumeroSerie).HasMaxLength(100);
        b.Property(x => x.SenhaTela).HasMaxLength(20);
        b.Property(x => x.Ativo).IsRequired();
        b.Property(x => x.CriadoEm).IsRequired();
        b.Property(x => x.AtualizadoEm).IsRequired();

        b.HasIndex(x => x.ClienteId);
        b.HasIndex(x => x.MarcaId);

        // FK para Cliente
        b.HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK para Marca
        b.HasOne(a => a.Marca)
            .WithMany()
            .HasForeignKey(a => a.MarcaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
