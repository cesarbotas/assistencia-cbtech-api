using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Clientes.ListarClientes;

public interface IListarClientesHandler
{
    Task<Result<ResultadoPaginado<ClienteResponse>>> Handle(ListarClientesRequest request, CancellationToken ct = default);
}
