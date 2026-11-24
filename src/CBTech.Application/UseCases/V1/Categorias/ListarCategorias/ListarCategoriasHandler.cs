using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Categorias.ListarCategorias;

public sealed class ListarCategoriasHandler(ICategoriaRepository categoriaRepository) : IListarCategoriasHandler
{
    public async Task<Result<ResultadoPaginado<CategoriaResponse>>> Handle(ListarCategoriasRequest request, CancellationToken ct = default)
    {
        var normalized = request.Normalized();
        var (items, total) = await categoriaRepository.ListAsync(normalized.Pagina, normalized.Tamanho, normalized.Search, ct);
        var responses = items.Select(categoria => new CategoriaResponse(categoria.Id, categoria.Nome, categoria.Descricao)).ToList();

        return Result<ResultadoPaginado<CategoriaResponse>>.Ok(
            new ResultadoPaginado<CategoriaResponse>(responses, total, normalized.Pagina, normalized.Tamanho));
    }
}