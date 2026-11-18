namespace CBTech.Application.UseCases.V1.Usuarios.CreateUsuario;

public record CreateUsuarioRequest(
    string Nome,
    string Email,
    string Senha,
    string? Telefone,
    IReadOnlyList<int> RoleIds
);