using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Marcas.ListarMarcas;

public interface IListarMarcasHandler
{
    Task<Result<ResultadoPaginado<MarcaResponse>>> Handle(ListarMarcasRequest request, CancellationToken ct = default);
}
