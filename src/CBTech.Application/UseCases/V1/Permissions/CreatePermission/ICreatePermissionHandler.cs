using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Permissions.CreatePermission;

public interface ICreatePermissionHandler
{
    Task<Result<CreatePermissionResponse>> Handle(CreatePermissionRequest request, CancellationToken ct = default);
}
