using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Categorias.ConsultarCategoriaPorId;

public sealed class ConsultarCategoriaPorIdHandler(ICategoriaRepository categoriaRepository) : IConsultarCategoriaPorIdHandler
{
    public async Task<Result<CategoriaResponse>> Handle(Guid id, CancellationToken ct = default)
    {
        var categoria = await categoriaRepository.GetByIdAsync(id, ct);
        if (categoria is null)
            return Result<CategoriaResponse>.Fail("Categoria não encontrada.", 404);

        return Result<CategoriaResponse>.Ok(new CategoriaResponse(categoria.Id, categoria.Nome, categoria.Descricao));
    }
}