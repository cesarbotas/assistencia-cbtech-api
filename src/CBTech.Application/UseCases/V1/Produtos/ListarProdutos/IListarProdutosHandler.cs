using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Produtos.ListarProdutos;

public interface IListarProdutosHandler
{
    Task<Result<ResultadoPaginado<ProdutoResponse>>> Handle(ListarProdutosRequest request, CancellationToken ct = default);
}