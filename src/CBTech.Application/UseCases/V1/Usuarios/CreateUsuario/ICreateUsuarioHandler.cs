using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Usuarios.CreateUsuario;

public interface ICreateUsuarioHandler
{
    Task<Result<CreateUsuarioResponse>> Handle(CreateUsuarioRequest request, CancellationToken ct = default);
}
