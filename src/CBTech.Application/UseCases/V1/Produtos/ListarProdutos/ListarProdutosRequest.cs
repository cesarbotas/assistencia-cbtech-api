namespace CBTech.Application.UseCases.V1.Produtos.ListarProdutos;

public sealed record ListarProdutosRequest(
    int Pagina = 1,
    int Tamanho = 10,
    string? Search = null,
    Guid? CategoriaId = null,
    Guid? FornecedorId = null)
{
    public ListarProdutosRequest Normalized() => this with
    {
        Pagina = Pagina < 1 ? 1 : Pagina,
        Tamanho = Tamanho < 1 ? 10 : Math.Min(Tamanho, 100),
        Search = string.IsNullOrWhiteSpace(Search) ? null : Search.Trim()
    };
}