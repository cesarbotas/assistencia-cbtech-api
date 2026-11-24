using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Aparelhos.ExcluirAparelho;

public interface IExcluirAparelhoHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}
