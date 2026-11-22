using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Marcas.ConsultarMarcaPorId;

public interface IConsultarMarcaPorIdHandler
{
    Task<Result<MarcaResponse>> Handle(Guid id, CancellationToken ct = default);
}
