using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.LogoutAll;

public interface ILogoutAllHandler
{
    Task<Result<bool>> Handle(Guid usuarioId, CancellationToken ct = default);
}
