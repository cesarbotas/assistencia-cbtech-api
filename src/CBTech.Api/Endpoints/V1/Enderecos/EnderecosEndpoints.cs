using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Enderecos.BuscarEnderecoPorCep;

namespace CBTech.Api.Endpoints.V1.Enderecos;

public static class EnderecosEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        // Consulta pública de endereço por CEP (usada no autopreenchimento do
        // formulário de endereço). Read-only; não grava nada.
        group.MapGet("/cep/{cep}", async (string cep, IBuscarEnderecoPorCepHandler handler, CancellationToken ct) =>
            (await handler.Handle(cep, ct)).ToHttpResult());
    }
}
