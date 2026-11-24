using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhos;

public interface IListarAparelhosHandler
{
    Task<Result<ResultadoPaginado<AparelhoResponse>>> Handle(ListarAparelhosRequest request, CancellationToken ct = default);
}
