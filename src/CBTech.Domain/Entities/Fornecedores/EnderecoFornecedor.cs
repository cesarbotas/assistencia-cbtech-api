namespace CBTech.Domain.Entities.Fornecedores;

public class EnderecoFornecedor
{
    public Guid Id { get; set; }
    public Guid FornecedorId { get; set; }
    public string Logradouro { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Estado { get; set; } = default!;
    public string Cep { get; set; } = default!;

    public void AtualizarEndereco(EnderecoFornecedorRequest request)
    {
        Logradouro = request.Logradouro;
        Numero = request.Numero;
        Complemento = request.Complemento;
        Bairro = request.Bairro;
        Cidade = request.Cidade;
        Estado = request.Estado;
        Cep = request.Cep;
    }
}
