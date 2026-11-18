using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.Logout;

public interface ILogoutHandler
{
    Task<Result<bool>> Handle(Guid usuarioId, LogoutRequest request, CancellationToken ct = default);
}
