namespace CBTech.Application.UseCases.V1.Fornecedores;

public record FornecedorResponse(
    Guid Id,
    string NomeFantasia,
    string RazaoSocial,
    string? Cnpj,
    string? Contato,
    string? Telefone,
    string? Whatsapp,
    string? Email,
    EnderecoFornecedorResponse? Endereco,
    int PrazoEntregaDias,
    string? CondicaoPagamento,
    bool Ativo,
    DateTime CriadoEm
);

public record EnderecoFornecedorResponse(
    Guid Id,
    Guid FornecedorId,
    string Logradouro,
    string Numero,
    string? Complemento,
    string Bairro,
    string Cidade,
    string Estado,
    string Cep
);
