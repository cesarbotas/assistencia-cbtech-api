using CBTech.Domain.Common;
using CBTech.Domain.Repositories;
using CBTech.Domain.Services.Interfaces;
using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Application.UseCases.V1.Clientes.CriarCliente;

public sealed class CriarClienteHandler(IClienteRepository clientes, IClock clock) : ICriarClienteHandler
{
    public async Task<Result<CriarClienteResponse>> Handle(CriarClienteRequest request, CancellationToken ct = default)
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone,
            CriadoEm = clock.UtcNow,
            Endereco = new Endereco
            {
                Id = Guid.NewGuid(),
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Bairro = request.Endereco.Bairro,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado,
                Cep = request.Endereco.Cep
            }
        };

        await clientes.AddAsync(cliente, ct);

        await clientes.SaveChangesAsync(ct);

        return Result<CriarClienteResponse>.Ok(new CriarClienteResponse(cliente.Id));
    }
}
