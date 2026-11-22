namespace CBTech.Domain.Entities.Enderecos;

public record EnderecoRequest(
    string Logradouro,
    string Numero,
    string? Complemento,
    string Bairro,
    string Cidade,
    string Estado,
    string Cep
);
