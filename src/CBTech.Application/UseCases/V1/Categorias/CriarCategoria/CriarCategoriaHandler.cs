using CBTech.Application.Common;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Repositories;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Categorias.CriarCategoria;

public sealed class CriarCategoriaHandler(
    ICategoriaRepository categoriaRepository,
    IValidator<CriarCategoriaRequest> validator) : ICriarCategoriaHandler
{
    public async Task<Result<CriarCategoriaResponse>> Handle(CriarCategoriaRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result<CriarCategoriaResponse>.ValidationFail(validation.ToValidationErrors());

        var categoria = Categoria.Criar(request);
        await categoriaRepository.AddAsync(categoria, ct);
        await categoriaRepository.SaveChangesAsync(ct);

        return Result<CriarCategoriaResponse>.Ok(new CriarCategoriaResponse(categoria.Id));
    }
}