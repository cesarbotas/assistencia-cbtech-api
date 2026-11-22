using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Clientes.ConsultarClientePorId;

public interface IConsultarClientePorIdHandler
{
    Task<Result<ClienteResponse>> Handle(Guid id, CancellationToken ct = default);
}
