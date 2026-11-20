using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Application.UseCases.V1.Clientes.CriarCliente;

public record CriarClienteRequest(
    string Nome,
    string Email,
    string? Telefone,
    EnderecoRequest Endereco
);
