using CBTech.Domain.Entities.Aparelhos;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Aparelhos.AtualizarAparelho;

public class AtualizarAparelhoValidator : AbstractValidator<AtualizarAparelhoRequest>
{
    public AtualizarAparelhoValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEmpty();

        RuleFor(x => x.MarcaId)
            .NotEmpty();

        RuleFor(x => x.Modelo)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Cor)
            .MaximumLength(50);

        RuleFor(x => x.Imei1)
            .MaximumLength(17);

        RuleFor(x => x.Imei2)
            .MaximumLength(17);

        RuleFor(x => x.NumeroSerie)
            .MaximumLength(100);

        RuleFor(x => x.SenhaTela)
            .MaximumLength(20);
    }
}
