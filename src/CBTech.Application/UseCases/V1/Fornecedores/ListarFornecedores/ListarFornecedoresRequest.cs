namespace CBTech.Application.UseCases.V1.Fornecedores.ListarFornecedores;

public sealed record ListarFornecedoresRequest(
    int Pagina = 1,
    int Tamanho = 10,
    string? Search = null)
{
    public ListarFornecedoresRequest Normalized() => this with
    {
        Pagina = Pagina < 1 ? 1 : Pagina,
        Tamanho = Tamanho < 1 ? 10 : Math.Min(Tamanho, 100),
        Search = string.IsNullOrWhiteSpace(Search) ? null : Search.Trim()
    };
}
