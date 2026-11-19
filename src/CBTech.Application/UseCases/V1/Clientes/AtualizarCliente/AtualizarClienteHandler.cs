using CBTech.Domain.Common;
using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.AtualizarCliente;

public sealed class AtualizarClienteHandler(IClienteRepository clientes) : IAtualizarClienteHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarClienteRequest request, CancellationToken ct = default)
    {
        var cliente = await clientes.GetByIdAsync(id, ct);

        if (cliente is null) return Result<bool>.Fail("Cliente não encontrado.");

        cliente.AtualizarCliente(request);

        await clientes.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
