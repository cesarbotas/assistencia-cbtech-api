using CBTech.Domain.Common;
using CBTech.Domain.Entities.Clientes;

namespace CBTech.Application.UseCases.V1.Clientes.AtualizarCliente;

public interface IAtualizarClienteHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarClienteRequest request, CancellationToken ct = default);
}
