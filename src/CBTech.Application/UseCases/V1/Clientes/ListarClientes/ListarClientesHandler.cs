using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Clientes.ListarClientes;

public sealed class ListarClientesHandler(IClienteRepository clientes) : IListarClientesHandler
{
    public async Task<Result<ResultadoPaginado<ClienteResponse>>> Handle(ListarClientesRequest request, CancellationToken ct = default)
    {
        var (items, total) = await clientes.ListAsync(request.Pagina, request.Tamanho, request.Search, ct);

        var dtos = items.Select(c =>
            new ClienteResponse(
                    c.Id,
                    c.Nome,
                    c.Email,
                    c.Telefone,
                    new EnderecoResponse(
                        c.Endereco.Id,
                        c.Id,
                        c.Endereco.Logradouro,
                        c.Endereco.Numero,
                        c.Endereco.Complemento,
                        c.Endereco.Bairro,
                        c.Endereco.Cidade,
                        c.Endereco.Estado,
                        c.Endereco.Cep),
                    c.CriadoEm)).ToList();

        return Result<ResultadoPaginado<ClienteResponse>>.Ok(new ResultadoPaginado<ClienteResponse>(dtos, total, request.Pagina, request.Tamanho));
    }
}

