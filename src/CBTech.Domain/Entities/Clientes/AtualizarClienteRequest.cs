using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Domain.Entities.Clientes;

public record AtualizarClienteRequest(
    string Nome,
    string Email,
    string? Telefone,
    EnderecoRequest Endereco
);
