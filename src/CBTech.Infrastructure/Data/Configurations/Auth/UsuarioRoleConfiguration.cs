using CBTech.Domain.Entities.Auth.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTech.Infrastructure.Data.Configurations.Auth;

public class UsuarioRoleConfiguration : IEntityTypeConfiguration<UsuarioRole>
{
    public void Configure(EntityTypeBuilder<UsuarioRole> b)
    {
        b.HasKey(x => new { x.UsuarioId, x.RoleId });

        b.HasOne(x => x.Usuario)
            .WithMany(u => u.UsuarioRoles)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.Role)
            .WithMany(r => r.UsuarioRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
