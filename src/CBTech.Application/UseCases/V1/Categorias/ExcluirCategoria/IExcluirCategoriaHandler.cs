using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Categorias.ExcluirCategoria;

public interface IExcluirCategoriaHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}