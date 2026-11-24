using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Aparelhos.ExcluirAparelho;

public sealed class ExcluirAparelhoHandler(IAparelhoRepository aparelhoRepository) : IExcluirAparelhoHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var aparelho = await aparelhoRepository.GetByIdAsync(id, ct);

        if (aparelho is null) return Result<bool>.Fail("Aparelho não encontrado.");

        await aparelhoRepository.DeleteAsync(aparelho, ct);

        await aparelhoRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
