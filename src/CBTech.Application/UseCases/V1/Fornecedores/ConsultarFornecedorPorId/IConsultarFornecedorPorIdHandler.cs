using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Fornecedores.ConsultarFornecedorPorId;

public interface IConsultarFornecedorPorIdHandler
{
    Task<Result<FornecedorResponse>> Handle(Guid id, CancellationToken ct = default);
}
