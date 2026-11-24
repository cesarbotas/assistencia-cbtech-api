using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Produtos.ListarProdutos;

public sealed class ListarProdutosHandler(IProdutoRepository produtoRepository) : IListarProdutosHandler
{
    public async Task<Result<ResultadoPaginado<ProdutoResponse>>> Handle(ListarProdutosRequest request, CancellationToken ct = default)
    {
        var normalized = request.Normalized();
        var (items, total) = await produtoRepository.ListAsync(
            normalized.Pagina,
            normalized.Tamanho,
            normalized.Search,
            normalized.CategoriaId,
            normalized.FornecedorId,
            ct);
        var responses = items.Select(ProdutoResponse.From).ToList();

        return Result<ResultadoPaginado<ProdutoResponse>>.Ok(
            new ResultadoPaginado<ProdutoResponse>(responses, total, normalized.Pagina, normalized.Tamanho));
    }
}