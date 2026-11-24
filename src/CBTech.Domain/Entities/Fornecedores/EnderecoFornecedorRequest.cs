namespace CBTech.Domain.Entities.Fornecedores;

public record EnderecoFornecedorRequest(
    string Logradouro,
    string Numero,
    string? Complemento,
    string Bairro,
    string Cidade,
    string Estado,
    string Cep
);
