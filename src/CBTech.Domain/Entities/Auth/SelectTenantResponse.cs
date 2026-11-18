namespace CBTech.Contracts.Auth;

public sealed record SelectTenantResponse(
    string AccessToken,
    string RefreshToken,
    string UserId,
    string UserName,
    string UserEmail,
    Guid ActiveTenantId,
    string ActiveTenantName,
    string UserRole,
    bool IsSubscriptionActive
);
