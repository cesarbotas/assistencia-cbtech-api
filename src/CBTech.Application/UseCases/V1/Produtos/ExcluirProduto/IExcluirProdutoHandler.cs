using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Produtos.ExcluirProduto;

public interface IExcluirProdutoHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}