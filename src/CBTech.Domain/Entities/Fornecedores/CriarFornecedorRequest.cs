namespace CBTech.Domain.Entities.Fornecedores;

public record CriarFornecedorRequest(
    string NomeFantasia,
    string RazaoSocial,
    string? Cnpj,
    string? Contato,
    string? Telefone,
    string? Whatsapp,
    string? Email,
    EnderecoFornecedorRequest? Endereco,
    int PrazoEntregaDias,
    string? CondicaoPagamento,
    bool Ativo
);
