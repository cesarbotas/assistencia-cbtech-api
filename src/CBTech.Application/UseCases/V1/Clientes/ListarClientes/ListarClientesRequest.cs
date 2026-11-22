namespace CBTech.Application.UseCases.V1.Clientes.ListarClientes;

public sealed record ListarClientesRequest(
    int Pagina = 1,
    int Tamanho = 10,
    string? Search = null)
{
    public ListarClientesRequest Normalized() => this with
    {
        Pagina = Pagina < 1 ? 1 : Pagina,
        Tamanho = Tamanho < 1 ? 10 : Math.Min(Tamanho, 100), // teto de segurança
        Search = string.IsNullOrWhiteSpace(Search) ? null : Search.Trim()
    };
}
