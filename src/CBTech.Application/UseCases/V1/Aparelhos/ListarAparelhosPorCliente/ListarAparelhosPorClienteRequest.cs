namespace CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhosPorCliente;

public sealed record ListarAparelhosPorClienteRequest(
    int Pagina = 1,
    int Tamanho = 10,
    string? Search = null)
{
    public ListarAparelhosPorClienteRequest Normalized() => this with
    {
        Pagina = Pagina < 1 ? 1 : Pagina,
        Tamanho = Tamanho < 1 ? 10 : Math.Min(Tamanho, 100),
        Search = string.IsNullOrWhiteSpace(Search) ? null : Search.Trim()
    };
}
