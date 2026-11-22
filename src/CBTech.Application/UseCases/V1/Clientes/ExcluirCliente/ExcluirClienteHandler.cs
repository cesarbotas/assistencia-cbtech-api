using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.ExcluirCliente;

public sealed class ExcluirClienteHandler(IClienteRepository clienteRepository) : IExcluirClienteHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var cliente = await clienteRepository.GetByIdAsync(id, ct);

        if (cliente is null) return Result<bool>.Fail("Cliente não encontrado.");

        await clienteRepository.DeleteAsync(cliente, ct);

        await clienteRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
