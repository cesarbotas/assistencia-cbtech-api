using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Produtos.ConsultarProdutoPorId;

public sealed class ConsultarProdutoPorIdHandler(IProdutoRepository produtoRepository) : IConsultarProdutoPorIdHandler
{
    public async Task<Result<ProdutoResponse>> Handle(Guid id, CancellationToken ct = default)
    {
        var produto = await produtoRepository.GetByIdAsync(id, ct);
        return produto is null
            ? Result<ProdutoResponse>.Fail("Produto não encontrado.", 404)
            : Result<ProdutoResponse>.Ok(ProdutoResponse.From(produto));
    }
}