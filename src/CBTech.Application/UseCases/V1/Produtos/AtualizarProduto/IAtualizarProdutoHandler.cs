using CBTech.Domain.Common;
using CBTech.Domain.Entities.Produtos;

namespace CBTech.Application.UseCases.V1.Produtos.AtualizarProduto;

public interface IAtualizarProdutoHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarProdutoRequest request, CancellationToken ct = default);
}