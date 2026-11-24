using CBTech.Domain.Entities.Categorias;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Categorias.CriarCategoria;

public class CriarCategoriaValidator : AbstractValidator<CriarCategoriaRequest>
{
    public CriarCategoriaValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(request => request.Descricao)
            .MaximumLength(200);
    }
}