using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Categorias.ListarCategorias;

public interface IListarCategoriasHandler
{
    Task<Result<ResultadoPaginado<CategoriaResponse>>> Handle(ListarCategoriasRequest request, CancellationToken ct = default);
}