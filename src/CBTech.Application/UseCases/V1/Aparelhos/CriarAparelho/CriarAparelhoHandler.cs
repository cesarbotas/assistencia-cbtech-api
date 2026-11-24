using CBTech.Domain.Common;
using CBTech.Domain.Repositories;
using CBTech.Domain.Entities.Aparelhos;

namespace CBTech.Application.UseCases.V1.Aparelhos.CriarAparelho;

public sealed class CriarAparelhoHandler(IAparelhoRepository aparelhoRepository) : ICriarAparelhoHandler
{
    public async Task<Result<CriarAparelhoResponse>> Handle(CriarAparelhoRequest request, CancellationToken ct = default)
    {
        var aparelho = Aparelho.Criar(request);

        await aparelhoRepository.AddAsync(aparelho, ct);
        await aparelhoRepository.SaveChangesAsync(ct);

        return Result<CriarAparelhoResponse>.Ok(new CriarAparelhoResponse(aparelho.Id));
    }
}
