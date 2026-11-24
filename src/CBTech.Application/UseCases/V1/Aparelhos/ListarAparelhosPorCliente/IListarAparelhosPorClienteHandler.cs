using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhosPorCliente;

public interface IListarAparelhosPorClienteHandler
{
    Task<Result<ResultadoPaginado<AparelhoResponse>>> Handle(Guid clienteId, ListarAparelhosPorClienteRequest request, CancellationToken ct = default);
}
