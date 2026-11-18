using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Enderecos.BuscarEnderecoPorCep;

public interface IBuscarEnderecoPorCepHandler
{
    Task<Result<EnderecoCepResponse>> Handle(string cep, CancellationToken ct = default);
}
