using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Marcas;
using CBTech.Application.UseCases.V1.Marcas.AtualizarMarca;
using CBTech.Application.UseCases.V1.Marcas.ConsultarMarcaPorId;
using CBTech.Application.UseCases.V1.Marcas.CriarMarca;
using CBTech.Application.UseCases.V1.Marcas.ExcluirMarca;
using CBTech.Application.UseCases.V1.Marcas.ListarMarcas;
using CBTech.Domain.Entities.Marcas;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Marcas;

public static class MarcasEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
            group.MapGet("/", async (
                    [AsParameters] ListarMarcasRequest request,
                    IListarMarcasHandler handler,
                    CancellationToken ct) =>
                {
                    var result = await handler.Handle(request.Normalized(), ct);
                    return result.ToHttpResult();
                })
                .Produces<MarcaResponse>(StatusCodes.Status200OK)
                .RequirePermission("Marcas:ler");

            group.MapGet("/{id:guid}", async (Guid id, IConsultarMarcaPorIdHandler handler, CancellationToken ct) =>
                    (await handler.Handle(id, ct)).ToHttpResult())
                .RequirePermission("marcas:ler");

            group.MapPost("/", async ([FromBody] CriarMarcaRequest request, ICriarMarcaHandler handler, CancellationToken ct) =>
                (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
                .RequirePermission("marcas:escrever");

            group.MapPut("/{id:guid}", async
                    (
                        Guid id,
                        [FromBody] AtualizarMarcaRequest request,
                        IAtualizarMarcaHandler handler,
                        CancellationToken ct
                    ) =>
                    (
                        await handler.Handle(id, request, ct)).ToHttpResult()
                )
                .RequirePermission("marcas:escrever");

            group.MapDelete("/{id:guid}", async (Guid id, IExcluirMarcaHandler handler, CancellationToken ct) =>
                    (await handler.Handle(id, ct)).ToHttpResult())
                .RequirePermission("marcas:escrever");
        }
}
