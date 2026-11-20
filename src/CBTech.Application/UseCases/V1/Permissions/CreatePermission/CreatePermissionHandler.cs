using CBTech.Domain.Common;
using CBTech.Domain.Entities.Auth;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Permissions.CreatePermission;

public sealed class CreatePermissionHandler(IPermissionRepository permissions) : ICreatePermissionHandler
{
    public async Task<Result<CreatePermissionResponse>> Handle(CreatePermissionRequest request, CancellationToken ct = default)
    {
        if (await permissions.GetByCodigoAsync(request.Codigo, ct) is not null)
            return Result<CreatePermissionResponse>.Fail("Já existe uma permissão com este código.");

        var permission = new Permission
        {
            Codigo = request.Codigo,
            Descricao = request.Descricao,
            Recurso = request.Recurso,
            Acao = request.Acao
        };

        await permissions.AddAsync(permission, ct);
        await permissions.SaveChangesAsync(ct);
        return Result<CreatePermissionResponse>.Ok(new CreatePermissionResponse(permission.Id));
    }
}
