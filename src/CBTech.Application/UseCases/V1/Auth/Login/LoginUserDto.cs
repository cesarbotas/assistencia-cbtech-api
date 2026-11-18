namespace CBTech.Application.UseCases.V1.Auth.Login;

public record LoginUserDto(Guid Id, string Nome, string Email, IReadOnlyList<string> Roles);