using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Marcas.ListarMarcas;

public sealed class ListarMarcasHandler(IMarcaRepository Marcas) : IListarMarcasHandler
{
    public async Task<Result<ResultadoPaginado<MarcaResponse>>> Handle(ListarMarcasRequest request, CancellationToken ct = default)
    {
        var (items, total) = await Marcas.ListAsync(request.Pagina, request.Tamanho, request.Search, ct);

        var dtos = items.Select(m =>
            new MarcaResponse(
                    m.Id,
                    m.Nome,
                    m.CriadoEm,
                    m.AtualizadoEm)).ToList();

        return Result<ResultadoPaginado<MarcaResponse>>.Ok(new ResultadoPaginado<MarcaResponse>(dtos, total, request.Pagina, request.Tamanho));
    }
}

