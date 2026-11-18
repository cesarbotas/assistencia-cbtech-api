using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Permissions.DeletePermission;

public interface IDeletePermissionHandler
{
    Task<Result<bool>> Handle(int id, CancellationToken ct = default);
}

public sealed class DeletePermissionHandler(IPermissionRepository permissions) : IDeletePermissionHandler
{
    public async Task<Result<bool>> Handle(int id, CancellationToken ct = default)
    {
        var permission = await permissions.GetByIdAsync(id, ct);
        if (permission is null) return Result<bool>.Fail("Permissão não encontrada.");

        permissions.Remove(permission);
        await permissions.SaveChangesAsync(ct);
        return Result<bool>.Ok(true);
    }
}
