using CBTech.Domain.Common;
using CBTech.Domain.Entities.Aparelhos;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Aparelhos.AtualizarAparelho;

public sealed class AtualizarAparelhoHandler(IAparelhoRepository aparelhoRepository) : IAtualizarAparelhoHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarAparelhoRequest request, CancellationToken ct = default)
    {
        var aparelho = await aparelhoRepository.GetByIdAsync(id, ct);

        if (aparelho is null) return Result<bool>.Fail("Aparelho não encontrado.");

        aparelho.AtualizarAparelho(request);

        await aparelhoRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
