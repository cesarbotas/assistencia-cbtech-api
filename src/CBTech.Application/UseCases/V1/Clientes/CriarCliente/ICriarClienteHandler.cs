using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Clientes.CriarCliente;

public interface ICriarClienteHandler
{
    Task<Result<CriarClienteResponse>> Handle(CriarClienteRequest request, CancellationToken ct = default);
}
