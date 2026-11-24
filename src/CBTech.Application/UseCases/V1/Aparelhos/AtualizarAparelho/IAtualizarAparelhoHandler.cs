using CBTech.Domain.Common;
using CBTech.Domain.Entities.Aparelhos;

namespace CBTech.Application.UseCases.V1.Aparelhos.AtualizarAparelho;

public interface IAtualizarAparelhoHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarAparelhoRequest request, CancellationToken ct = default);
}
