using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Usuarios.ListUsuarios;

public interface IListarUsuariosHandler
{
    Task<Result<IReadOnlyList<UsuarioResponse>>> Handle(CancellationToken ct = default);
}
