using CBTech.Application.Common;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Repositories;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Categorias.AtualizarCategoria;

public sealed class AtualizarCategoriaHandler(
    ICategoriaRepository categoriaRepository,
    IValidator<AtualizarCategoriaRequest> validator) : IAtualizarCategoriaHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarCategoriaRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result<bool>.ValidationFail(validation.ToValidationErrors());

        var categoria = await categoriaRepository.GetByIdAsync(id, ct);
        if (categoria is null)
            return Result<bool>.Fail("Categoria não encontrada.", 404);

        categoria.AtualizarCategoria(request);
        await categoriaRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}