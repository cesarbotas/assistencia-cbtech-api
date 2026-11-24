using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Produtos.ExcluirProduto;

public sealed class ExcluirProdutoHandler(IProdutoRepository produtoRepository) : IExcluirProdutoHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var produto = await produtoRepository.GetByIdAsync(id, ct);
        if (produto is null)
            return Result<bool>.Fail("Produto não encontrado.", 404);

        await produtoRepository.DeleteAsync(produto, ct);
        await produtoRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}