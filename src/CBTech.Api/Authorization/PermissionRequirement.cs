using Microsoft.AspNetCore.Authorization;

namespace CBTech.Api.Authorization;

/// <summary>
/// Requisito de autorização que exige a posse de uma permissão específica
/// (claim <c>perm</c> == <see cref="Codigo"/>).
/// </summary>
public sealed class PermissionRequirement(string codigo) : IAuthorizationRequirement
{
    public string Codigo { get; } = codigo;
}
