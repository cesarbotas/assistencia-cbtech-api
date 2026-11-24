using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Fornecedores.ListarFornecedores;

public interface IListarFornecedoresHandler
{
    Task<Result<ResultadoPaginado<FornecedorResponse>>> Handle(ListarFornecedoresRequest request, CancellationToken ct = default);
}
