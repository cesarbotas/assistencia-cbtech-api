using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Marcas.CriarMarca;

public interface ICriarMarcaHandler
{
    Task<Result<CriarMarcaResponse>> Handle(CriarMarcaRequest request, CancellationToken ct = default);
}
