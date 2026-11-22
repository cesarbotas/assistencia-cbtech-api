using FluentValidation;

namespace CBTech.Application.UseCases.V1.Permissions.CreatePermission;

public class CreatePermissionValidator : AbstractValidator<CreatePermissionRequest>
{
    public CreatePermissionValidator()
    {
        RuleFor(x => x.Codigo)
            .NotEmpty()
            .MaximumLength(100)
            .Must(c => c.Contains(':'))
            .WithMessage("Código deve seguir o formato recurso:acao.");

        RuleFor(x => x.Recurso).NotEmpty().MaximumLength(100);

        RuleFor(x => x.Acao).NotEmpty().MaximumLength(100);

        RuleFor(x => x.Descricao).MaximumLength(500);
    }
}
