using CBTech.Domain.Common;
using CBTech.Domain.Entities.Fornecedores;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Fornecedores.AtualizarFornecedor;

public sealed class AtualizarFornecedorHandler(IFornecedorRepository fornecedorRepository) : IAtualizarFornecedorHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarFornecedorRequest request, CancellationToken ct = default)
    {
        var fornecedor = await fornecedorRepository.GetByIdAsync(id, ct);

        if (fornecedor is null) return Result<bool>.Fail("Fornecedor não encontrado.");

        fornecedor.AtualizarFornecedor(request);

        await fornecedorRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
