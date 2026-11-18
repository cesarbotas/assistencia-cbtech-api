using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Auth.GetCurrentUser;

public sealed class GetCurrentUserHandler : IGetCurrentUserHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetCurrentUserHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<GetCurrentUserResponse>> Handle(Guid userId, CancellationToken ct = default)
    {
        var usuario = await _usuarioRepository.GetByIdComRolesAsync(userId, ct);
        if (usuario is null)
            return Result<GetCurrentUserResponse>.Fail("Usuário não encontrado.");

        var roles = usuario.UsuarioRoles.Select(ur => ur.Role.Nome).ToList();

        return Result<GetCurrentUserResponse>.Ok(
            new GetCurrentUserResponse(usuario.Id, usuario.Nome, usuario.Email, roles));
    }
}
