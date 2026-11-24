using CBTech.Domain.Common;
using CBTech.Domain.Entities.Fornecedores;

namespace CBTech.Application.UseCases.V1.Fornecedores.CriarFornecedor;

public interface ICriarFornecedorHandler
{
    Task<Result<CriarFornecedorResponse>> Handle(CriarFornecedorRequest request, CancellationToken ct = default);
}
