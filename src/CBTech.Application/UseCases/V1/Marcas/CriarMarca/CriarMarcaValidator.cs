using FluentValidation;

namespace CBTech.Application.UseCases.V1.Marcas.CriarMarca;

public class CriarMarcaValidator : AbstractValidator<CriarMarcaRequest>
{
    public CriarMarcaValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(100);
    }
}
