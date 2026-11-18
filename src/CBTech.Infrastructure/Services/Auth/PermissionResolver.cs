using CBTech.Domain.Services.Interfaces;
using CBTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Services.Auth;

public class PermissionResolver(AppDbContext db) : IPermissionResolver
{
    public async Task<(IReadOnlyList<string> Roles, IReadOnlyList<string> Permissoes)> ResolveAsync(Guid usuarioId, CancellationToken ct = default)
    {
        var roles = await db.UsuarioRoles
            .AsNoTracking()
            .Where(ur => ur.UsuarioId == usuarioId)
            .Select(ur => ur.Role.Nome)
            .Distinct()
            .ToListAsync(ct);

        var permissoes = await db.UsuarioRoles
            .AsNoTracking()
            .Where(ur => ur.UsuarioId == usuarioId)
            .SelectMany(ur => ur.Role.RolePermissions.Select(rp => rp.Permission.Codigo))
            .Distinct()
            .ToListAsync(ct);

        return (roles, permissoes);
    }
}
