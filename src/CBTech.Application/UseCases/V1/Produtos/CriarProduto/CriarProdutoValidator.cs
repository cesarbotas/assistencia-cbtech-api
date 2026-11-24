using CBTech.Domain.Entities.Produtos;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Produtos.CriarProduto;

public class CriarProdutoValidator : AbstractValidator<CriarProdutoRequest>
{
    public CriarProdutoValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(request => request.Sku)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(request => request.CodigoBarras)
            .MaximumLength(50);

        RuleFor(request => request.CategoriaId)
            .NotEmpty();

        RuleFor(request => request.FornecedorId)
            .NotEmpty();

        RuleFor(request => request.PrecoCusto)
            .GreaterThanOrEqualTo(0);

        RuleFor(request => request.PrecoVenda)
            .GreaterThanOrEqualTo(0);

        RuleFor(request => request.EstoqueAtual)
            .GreaterThanOrEqualTo(0);

        RuleFor(request => request.EstoqueMinimo)
            .GreaterThanOrEqualTo(0);

        RuleFor(request => request.UnidadeMedida)
            .NotEmpty()
            .MaximumLength(10);
    }
}