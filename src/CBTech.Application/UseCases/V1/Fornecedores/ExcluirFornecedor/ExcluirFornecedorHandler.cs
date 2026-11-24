using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Fornecedores.ExcluirFornecedor;

public sealed class ExcluirFornecedorHandler(IFornecedorRepository fornecedorRepository) : IExcluirFornecedorHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var fornecedor = await fornecedorRepository.GetByIdAsync(id, ct);

        if (fornecedor is null) return Result<bool>.Fail("Fornecedor não encontrado.");

        await fornecedorRepository.DeleteAsync(fornecedor, ct);

        await fornecedorRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
