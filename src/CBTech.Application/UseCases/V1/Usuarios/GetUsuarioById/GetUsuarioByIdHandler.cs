using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Usuarios.GetUsuarioById;

public interface IGetUsuarioByIdHandler
{
    Task<Result<UsuarioResponse>> Handle(Guid id, CancellationToken ct = default);
}

public sealed class GetUsuarioByIdHandler(IUsuarioRepository usuarios) : IGetUsuarioByIdHandler
{
    public async Task<Result<UsuarioResponse>> Handle(Guid id, CancellationToken ct = default)
    {
        var usuario = await usuarios.GetByIdComRolesAsync(id, ct);
        if (usuario is null) return Result<UsuarioResponse>.Fail("Usuário não encontrado.");

        return Result<UsuarioResponse>.Ok(UsuarioMapper.ToResponse(usuario));
    }
}
