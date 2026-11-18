using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Usuarios.ListUsuarios;

public interface IListUsuariosHandler
{
    Task<Result<IReadOnlyList<UsuarioResponse>>> Handle(CancellationToken ct = default);
}

public sealed class ListUsuariosHandler(IUsuarioRepository usuarios) : IListUsuariosHandler
{
    public async Task<Result<IReadOnlyList<UsuarioResponse>>> Handle(CancellationToken ct = default)
    {
        var items = await usuarios.ListAsync(ct);
        IReadOnlyList<UsuarioResponse> dtos = items.Select(UsuarioMapper.ToResponse).ToList();
        return Result<IReadOnlyList<UsuarioResponse>>.Ok(dtos);
    }
}
