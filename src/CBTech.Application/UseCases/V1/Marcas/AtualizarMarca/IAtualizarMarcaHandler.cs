using CBTech.Domain.Common;
using CBTech.Domain.Entities.Marcas;

namespace CBTech.Application.UseCases.V1.Marcas.AtualizarMarca;

public interface IAtualizarMarcaHandler
{
    Task<Result<bool>> Handle(Guid id, AtualizarMarcaRequest request, CancellationToken ct = default);
}
