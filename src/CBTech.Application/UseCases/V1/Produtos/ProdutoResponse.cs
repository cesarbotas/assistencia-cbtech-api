using CBTech.Domain.Entities.Produtos;

namespace CBTech.Application.UseCases.V1.Produtos;

public record ProdutoResponse(
    Guid Id,
    string Nome,
    string Sku,
    string? CodigoBarras,
    Guid CategoriaId,
    Guid FornecedorId,
    decimal PrecoCusto,
    decimal PrecoVenda,
    int EstoqueAtual,
    int EstoqueMinimo,
    string UnidadeMedida,
    bool Ativo,
    DateTime CriadoEm,
    DateTime AtualizadoEm)
{
    public static ProdutoResponse From(Produto produto) => new(
        produto.Id,
        produto.Nome,
        produto.Sku,
        produto.CodigoBarras,
        produto.CategoriaId,
        produto.FornecedorId,
        produto.PrecoCusto,
        produto.PrecoVenda,
        produto.EstoqueAtual,
        produto.EstoqueMinimo,
        produto.UnidadeMedida,
        produto.Ativo,
        produto.CriadoEm,
        produto.AtualizadoEm);
}