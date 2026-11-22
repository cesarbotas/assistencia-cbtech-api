namespace CBTech.Application.UseCases.V1.Permissions.CreatePermission;

public record CreatePermissionRequest(
    string Codigo,
    string? Descricao,
    string Recurso,
    string Acao
);
