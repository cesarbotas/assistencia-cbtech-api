using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Fornecedores.ExcluirFornecedor;

public interface IExcluirFornecedorHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}
