using CBTech.Domain.Entities.Auth.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Auth;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        b.Property(x => x.Email).HasMaxLength(200).IsRequired();
        b.HasIndex(x => x.Email).IsUnique();
        b.Property(x => x.SenhaHash).IsRequired();
        b.Property(x => x.Ativo).HasDefaultValue(true);
    }
}
