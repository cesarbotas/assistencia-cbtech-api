using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.ConsultarClientePorId;

public class ConsultarClientePorIdHandler(IClienteRepository clienteRepository) : IConsultarClientePorIdHandler
{
    public async Task<Result<ClienteResponse>> Handle(Guid id,
        CancellationToken ct = default)
    {
        var cliente = await clienteRepository.GetByIdAsync(id, ct);

        if (cliente == null)
        {
            return Result<ClienteResponse>.Fail("Cliente não encontrado.", 404);
        }

        var clienteDto =
            new ClienteResponse(
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                cliente.Telefone,
                new EnderecoResponse(
                    cliente.Endereco.Id,
                    cliente.Id,
                    cliente.Endereco.Logradouro,
                    cliente.Endereco.Numero,
                    cliente.Endereco.Complemento,
                    cliente.Endereco.Bairro,
                    cliente.Endereco.Cidade,
                    cliente.Endereco.Estado,
                    cliente.Endereco.Cep),
                cliente.CriadoEm);

        return Result<ClienteResponse>.Ok(clienteDto);
    }
}
