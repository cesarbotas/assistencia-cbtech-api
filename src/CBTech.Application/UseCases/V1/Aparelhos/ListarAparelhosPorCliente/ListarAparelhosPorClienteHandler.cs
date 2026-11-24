using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhosPorCliente;

public sealed class ListarAparelhosPorClienteHandler(IAparelhoRepository aparelhoRepository) : IListarAparelhosPorClienteHandler
{
    public async Task<Result<ResultadoPaginado<AparelhoResponse>>> Handle(Guid clienteId, ListarAparelhosPorClienteRequest request, CancellationToken ct = default)
    {
        var (items, total) = await aparelhoRepository.ListByClienteIdAsync(clienteId, request.Pagina, request.Tamanho, request.Search, ct);

        if (items == null)
        {
            return new Result<ResultadoPaginado<AparelhoResponse>>();
        }

        var dtos = items.Select(a =>
            new AparelhoResponse(
                a.Id,
                a.ClienteId,
                a.Cliente.Nome,
                a.MarcaId,
                a.Marca.Nome,
                a.Modelo,
                a.Cor,
                a.Imei1,
                a.Imei2,
                a.NumeroSerie,
                a.SenhaTela,
                a.Ativo,
                a.CriadoEm)).ToList();

        return Result<ResultadoPaginado<AparelhoResponse>>.Ok(new ResultadoPaginado<AparelhoResponse>(dtos, total, request.Pagina, request.Tamanho));
    }
}
