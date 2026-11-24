using CBTech.Domain.Common;
using CBTech.Domain.Entities.Produtos;

namespace CBTech.Application.UseCases.V1.Produtos.CriarProduto;

public interface ICriarProdutoHandler
{
    Task<Result<CriarProdutoResponse>> Handle(CriarProdutoRequest request, CancellationToken ct = default);
}