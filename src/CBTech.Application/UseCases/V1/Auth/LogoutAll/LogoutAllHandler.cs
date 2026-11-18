using CBTech.Domain.Repositories;
using CBTech.Domain.Services.Interfaces;
using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.LogoutAll;

public sealed class LogoutAllHandler(
    IRefreshTokenStore store,
    IClock clock) : ILogoutAllHandler
{
    public async Task<Result<bool>> Handle(Guid usuarioId, CancellationToken ct = default)
    {
        await store.RevokeAllForUserAsync(usuarioId, "LogoutAll", clock.UtcNow, ct);
        return Result<bool>.Ok(true);
    }
}
