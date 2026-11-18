using CBTech.Domain.Common;
using CBTech.Domain.Entities.Auth.Usuarios;
using CBTech.Domain.Repositories;
using CBTech.Domain.Services.Interfaces;

namespace CBTech.Application.UseCases.V1.Auth.RegisterUser;

public sealed class RegisterUserHandler(
    IUsuarioRepository usuarios,
    IRoleRepository roles,
    IPasswordHasher hasher,
    IClock clock) : IRegisterUserHandler
{
    public async Task<Result<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken ct = default)
    {
        var existing = await usuarios.GetByEmailAsync(request.Email, ct);
        if (existing is not null)
            return Result<RegisterUserResponse>.Fail("E-mail já cadastrado.");

        var usuario = new Usuario
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone,
            SenhaHash = hasher.Hash(request.Senha),
            Ativo = true,
            CriadoEm = clock.UtcNow
        };

        await usuarios.AddAsync(usuario, ct);
        await usuarios.SaveChangesAsync(ct);

        var clienteRole = await roles.GetByNomeAsync("Cliente", ct);
        if (clienteRole is not null)
        {
            await usuarios.SetRolesAsync(usuario.Id, new[] { clienteRole.Id }, ct);
            await usuarios.SaveChangesAsync(ct);
        }

        return Result<RegisterUserResponse>.Ok(
            new RegisterUserResponse(usuario.Id, usuario.Nome, usuario.Email, new[] { "Cliente" }));
    }
}
