namespace CBTech.Domain.Entities.Produtos;

public record CriarProdutoRequest(
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
    bool Ativo
);