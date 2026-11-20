using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Clientes.ExcluirCliente;

public interface IExcluirClienteHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}
