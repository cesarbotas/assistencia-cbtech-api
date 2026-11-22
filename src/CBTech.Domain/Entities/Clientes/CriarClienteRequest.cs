using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Domain.Entities.Clientes;

public record CriarClienteRequest(
    string Nome,
    string Email,
    string? Telefone,
    EnderecoRequest Endereco
);
