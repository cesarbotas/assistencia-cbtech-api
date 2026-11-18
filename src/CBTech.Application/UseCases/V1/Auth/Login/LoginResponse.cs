namespace CBTech.Application.UseCases.V1.Auth.Login;

public record LoginResponse(string AccessToken, string RefreshToken, int ExpiresIn, LoginUserDto User);

// public sealed record LoginResponse(
//     string? AccessToken,
//     string? RefreshToken,
//     string UserId,
//     string UserName,
//     string UserEmail,
//     Guid? ActiveTenantId,
//     string? ActiveTenantName,
//     string? UserRole,
//     bool? IsSubscriptionActive,
//     bool RequiresTenantSelection,
//     IReadOnlyList<AvailableTenantDto>? AvailableTenants
// );

// public sealed record AvailableTenantDto(
//     Guid Id,
//     string Nome,
//     string? Cnpj,
//     string Perfil,
//     bool IsSubscriptionActive
// );
