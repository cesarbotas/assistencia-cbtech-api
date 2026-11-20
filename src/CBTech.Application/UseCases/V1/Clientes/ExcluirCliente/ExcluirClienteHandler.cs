using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.ExcluirCliente;

public sealed class ExcluirClienteHandler(IClienteRepository clientes) : IExcluirClienteHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var cliente = await clientes.GetByIdAsync(id, ct);
        if (cliente is null) return Result<bool>.Fail("Cliente não encontrado.");
        await clientes.DeleteAsync(cliente, ct);
        await clientes.SaveChangesAsync(ct);
        return Result<bool>.Ok(true);
    }
}
