using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Categorias.ConsultarCategoriaPorId;

public interface IConsultarCategoriaPorIdHandler
{
    Task<Result<CategoriaResponse>> Handle(Guid id, CancellationToken ct = default);
}