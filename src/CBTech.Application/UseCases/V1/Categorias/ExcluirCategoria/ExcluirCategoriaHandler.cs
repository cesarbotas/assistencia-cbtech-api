using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Categorias.ExcluirCategoria;

public sealed class ExcluirCategoriaHandler(ICategoriaRepository categoriaRepository) : IExcluirCategoriaHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var categoria = await categoriaRepository.GetByIdAsync(id, ct);
        if (categoria is null)
            return Result<bool>.Fail("Categoria não encontrada.", 404);

        if (await categoriaRepository.HasProdutosAsync(id, ct))
            return Result<bool>.Fail("Não é possível excluir uma categoria que possui produtos vinculados.", 409);

        await categoriaRepository.DeleteAsync(categoria, ct);
        await categoriaRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}