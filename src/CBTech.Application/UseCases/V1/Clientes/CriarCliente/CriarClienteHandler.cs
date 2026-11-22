using CBTech.Domain.Common;
using CBTech.Domain.Repositories;
using CBTech.Domain.Entities.Clientes;

namespace CBTech.Application.UseCases.V1.Clientes.CriarCliente;

public sealed class CriarClienteHandler(IClienteRepository clienteRepository) : ICriarClienteHandler
{
    public async Task<Result<CriarClienteResponse>> Handle(CriarClienteRequest request, CancellationToken ct = default)
    {
        var cliente = Cliente.Criar(request);

        await clienteRepository.AddAsync(cliente, ct);

        await clienteRepository.SaveChangesAsync(ct);

        return Result<CriarClienteResponse>.Ok(new CriarClienteResponse(cliente.Id));
    }
}
