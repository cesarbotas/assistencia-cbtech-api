using FluentValidation;

namespace CBTech.Application.UseCases.V1.Usuarios.CreateUsuario;

public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioRequest>
{
    public CreateUsuarioValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(150);

        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);

        RuleFor(x => x.Senha).NotEmpty().MinimumLength(6);
        
        RuleFor(x => x.Telefone).MaximumLength(30);
    }
}
