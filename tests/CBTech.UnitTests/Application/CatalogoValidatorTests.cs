using CBTech.Application.UseCases.V1.Categorias.CriarCategoria;
using CBTech.Application.UseCases.V1.Produtos.CriarProduto;
using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Entities.Produtos;

namespace CBTech.UnitTests.Application;

public class CatalogoValidatorTests
{
    [Fact]
    public void CriarCategoriaValidator_deveRejeitarNomeVazioEDescricaoLonga()
    {
        var validator = new CriarCategoriaValidator();
        var result = validator.Validate(new CriarCategoriaRequest(" ", new string('x', 201)));

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CriarCategoriaRequest.Nome));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CriarCategoriaRequest.Descricao));
    }

    [Fact]
    public void CriarProdutoValidator_deveRejeitarPrecoEEstoqueNegativos()
    {
        var validator = new CriarProdutoValidator();
        var result = validator.Validate(new CriarProdutoRequest(
            "Produto", "SKU-1", null, Guid.NewGuid(), Guid.NewGuid(), -1m, 10m, -1, 0, "UN", true));

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CriarProdutoRequest.PrecoCusto));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CriarProdutoRequest.EstoqueAtual));
    }

    [Fact]
    public void CriarProdutoValidator_deveAceitarPayloadDeExemplo()
    {
        var validator = new CriarProdutoValidator();
        var result = validator.Validate(new CriarProdutoRequest(
            "Tela Frontal OLED iPhone 13",
            "TEL-IP13-OLED",
            "7891234567890",
            Guid.NewGuid(),
            Guid.NewGuid(),
            350m,
            650m,
            12,
            3,
            "UN",
            true));

        Assert.True(result.IsValid);
    }
}