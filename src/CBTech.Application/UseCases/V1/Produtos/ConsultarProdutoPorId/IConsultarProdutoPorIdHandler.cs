using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Produtos.ConsultarProdutoPorId;

public interface IConsultarProdutoPorIdHandler
{
    Task<Result<ProdutoResponse>> Handle(Guid id, CancellationToken ct = default);
}