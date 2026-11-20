using FluentValidation;

namespace CBTech.Application.UseCases.V1.Clientes.CriarCliente;

public class CriarClienteValidator : AbstractValidator<CriarClienteRequest>
{
    public CriarClienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Endereco).NotNull();

        RuleFor(x => x.Endereco.Logradouro)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Endereco.Numero)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Endereco.Bairro)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Endereco.Cidade)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Endereco.Estado)
            .NotEmpty()
            .Length(2);

        RuleFor(x => x.Endereco.Cep)
            .NotEmpty()
            .MaximumLength(8);
    }
}
