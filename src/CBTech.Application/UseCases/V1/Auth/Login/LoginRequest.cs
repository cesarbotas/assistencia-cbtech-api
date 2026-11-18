namespace CBTech.Application.UseCases.V1.Auth.Login;

public sealed record LoginRequest(
    string Email,
    string Senha
);
