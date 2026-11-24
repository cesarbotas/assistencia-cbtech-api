using CBTech.Domain.Common;
using CBTech.Domain.Entities.Categorias;

namespace CBTech.Application.UseCases.V1.Categorias.AtualizarCategoria;

public interface IAtualizarCategoriaHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarCategoriaRequest request, CancellationToken ct = default);
}