using CBTech.Domain.Entities.Categorias;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Categorias.AtualizarCategoria;

public class AtualizarCategoriaValidator : AbstractValidator<AtualizarCategoriaRequest>
{
    public AtualizarCategoriaValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(request => request.Descricao)
            .MaximumLength(200);
    }
}