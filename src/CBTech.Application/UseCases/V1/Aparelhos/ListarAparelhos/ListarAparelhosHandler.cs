using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhos;

public sealed class ListarAparelhosHandler(IAparelhoRepository aparelhoRepository) : IListarAparelhosHandler
{
    public async Task<Result<ResultadoPaginado<AparelhoResponse>>> Handle(ListarAparelhosRequest request,
        CancellationToken ct = default)
    {
        var (items, total) = await aparelhoRepository.ListAsync(request.Pagina, request.Tamanho, request.Search, ct);

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

        return Result<ResultadoPaginado<AparelhoResponse>>.Ok(
            new ResultadoPaginado<AparelhoResponse>(dtos, total, request.Pagina, request.Tamanho));
    }
}
