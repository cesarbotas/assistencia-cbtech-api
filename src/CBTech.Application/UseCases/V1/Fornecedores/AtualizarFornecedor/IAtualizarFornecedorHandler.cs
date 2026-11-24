using CBTech.Domain.Common;
using CBTech.Domain.Entities.Fornecedores;

namespace CBTech.Application.UseCases.V1.Fornecedores.AtualizarFornecedor;

public interface IAtualizarFornecedorHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarFornecedorRequest request, CancellationToken ct = default);
}
