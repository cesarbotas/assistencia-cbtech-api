using CBTech.Domain.Common;
using CBTech.Domain.Entities.Aparelhos;

namespace CBTech.Application.UseCases.V1.Aparelhos.CriarAparelho;

public interface ICriarAparelhoHandler
{
    Task<Result<CriarAparelhoResponse>> Handle(CriarAparelhoRequest request, CancellationToken ct = default);
}
