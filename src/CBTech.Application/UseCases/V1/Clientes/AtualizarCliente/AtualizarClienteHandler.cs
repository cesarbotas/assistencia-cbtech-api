using CBTech.Domain.Common;
using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.AtualizarCliente;

public sealed class AtualizarClienteHandler(IClienteRepository clienteRepository) : IAtualizarClienteHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarClienteRequest request, CancellationToken ct = default)
    {
        var cliente = await clienteRepository.GetByIdAsync(id, ct);

        if (cliente is null) return Result<bool>.Fail("Cliente não encontrado.");

        cliente.AtualizarCliente(request);

        await clienteRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
