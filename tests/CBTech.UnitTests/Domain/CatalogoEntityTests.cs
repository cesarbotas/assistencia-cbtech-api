using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Entities.Produtos;

namespace CBTech.UnitTests.Domain;

public class CatalogoEntityTests
{
    [Fact]
    public void CriarCategoria_deveMapearNomeEDescricao()
    {
        var categoria = Categoria.Criar(new CriarCategoriaRequest("Telas", "Peças de reposição"));

        Assert.NotEqual(Guid.Empty, categoria.Id);
        Assert.Equal("Telas", categoria.Nome);
        Assert.Equal("Peças de reposição", categoria.Descricao);
    }

    [Fact]
    public void CriarProduto_deveMapearCamposDoPayload()
    {
        var categoriaId = Guid.NewGuid();
        var fornecedorId = Guid.NewGuid();
        var produto = Produto.Criar(new CriarProdutoRequest(
            "Tela Frontal OLED iPhone 13",
            "TEL-IP13-OLED",
            "7891234567890",
            categoriaId,
            fornecedorId,
            350m,
            650m,
            12,
            3,
            "UN",
            true));

        Assert.NotEqual(Guid.Empty, produto.Id);
        Assert.Equal("Tela Frontal OLED iPhone 13", produto.Nome);
        Assert.Equal("TEL-IP13-OLED", produto.Sku);
        Assert.Equal("7891234567890", produto.CodigoBarras);
        Assert.Equal(categoriaId, produto.CategoriaId);
        Assert.Equal(fornecedorId, produto.FornecedorId);
        Assert.Equal(350m, produto.PrecoCusto);
        Assert.Equal(650m, produto.PrecoVenda);
        Assert.Equal(12, produto.EstoqueAtual);
        Assert.Equal(3, produto.EstoqueMinimo);
        Assert.Equal("UN", produto.UnidadeMedida);
        Assert.True(produto.Ativo);
        Assert.NotEqual(default, produto.CriadoEm);
        Assert.Equal(produto.CriadoEm, produto.AtualizadoEm);
    }

    [Fact]
    public void AtualizarProduto_deveAtualizarTodosOsCamposEditaveis()
    {
        var produto = Produto.Criar(new CriarProdutoRequest(
            "Produto antigo", "SKU-ANTIGO", null, Guid.NewGuid(), Guid.NewGuid(), 10m, 20m, 1, 0, "UN", true));
        var request = new AtualizarProdutoRequest(
            "Produto atualizado", "SKU-NOVO", "123456", Guid.NewGuid(), Guid.NewGuid(), 12m, 25m, 4, 2, "CX", false);

        produto.AtualizarProduto(request);

        Assert.Equal(request.Nome, produto.Nome);
        Assert.Equal(request.Sku, produto.Sku);
        Assert.Equal(request.CodigoBarras, produto.CodigoBarras);
        Assert.Equal(request.CategoriaId, produto.CategoriaId);
        Assert.Equal(request.FornecedorId, produto.FornecedorId);
        Assert.Equal(request.PrecoCusto, produto.PrecoCusto);
        Assert.Equal(request.PrecoVenda, produto.PrecoVenda);
        Assert.Equal(request.EstoqueAtual, produto.EstoqueAtual);
        Assert.Equal(request.EstoqueMinimo, produto.EstoqueMinimo);
        Assert.Equal(request.UnidadeMedida, produto.UnidadeMedida);
        Assert.False(produto.Ativo);
    }
}