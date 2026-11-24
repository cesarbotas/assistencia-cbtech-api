using CBTech.Domain.Common;
using CBTech.Domain.Entities.Categorias;

namespace CBTech.Application.UseCases.V1.Categorias.CriarCategoria;

public interface ICriarCategoriaHandler
{
    Task<Result<CriarCategoriaResponse>> Handle(CriarCategoriaRequest request, CancellationToken ct = default);
}