using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Marcas.ExcluirMarca;

public interface IExcluirMarcaHandler
{
    Task<Result<bool>> Handle(Guid id, CancellationToken ct = default);
}
