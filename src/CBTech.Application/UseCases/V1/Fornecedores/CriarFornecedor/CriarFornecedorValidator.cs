using CBTech.Domain.Entities.Fornecedores;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Fornecedores.CriarFornecedor;

public class CriarFornecedorValidator : AbstractValidator<CriarFornecedorRequest>
{
    public CriarFornecedorValidator()
    {
        RuleFor(x => x.NomeFantasia)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.RazaoSocial)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Cnpj)
            .MaximumLength(14)
            .When(x => !string.IsNullOrEmpty(x.Cnpj));

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Telefone)
            .MaximumLength(20)
            .When(x => !string.IsNullOrEmpty(x.Telefone));

        RuleFor(x => x.Whatsapp)
            .MaximumLength(20)
            .When(x => !string.IsNullOrEmpty(x.Whatsapp));

        RuleFor(x => x.PrazoEntregaDias)
            .GreaterThanOrEqualTo(0);

        When(x => x.Endereco != null, () =>
        {
            RuleFor(x => x.Endereco!.Logradouro)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Endereco!.Numero)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Endereco!.Bairro)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Endereco!.Cidade)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Endereco!.Estado)
                .NotEmpty()
                .Length(2);

            RuleFor(x => x.Endereco!.Cep)
                .NotEmpty()
                .MaximumLength(8);
        });
    }
}
