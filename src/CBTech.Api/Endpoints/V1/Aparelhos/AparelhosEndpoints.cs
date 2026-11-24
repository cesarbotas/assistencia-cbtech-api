using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Aparelhos;
using CBTech.Application.UseCases.V1.Aparelhos.AtualizarAparelho;
using CBTech.Application.UseCases.V1.Aparelhos.CriarAparelho;
using CBTech.Application.UseCases.V1.Aparelhos.ExcluirAparelho;
using CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhos;
using CBTech.Application.UseCases.V1.Aparelhos.ListarAparelhosPorCliente;
using CBTech.Domain.Entities.Aparelhos;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Aparelhos;

public static class AparelhosEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async (
                [AsParameters] ListarAparelhosRequest request,
                IListarAparelhosHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(request.Normalized(), ct);
                return result.ToHttpResult();
            })
            .Produces<AparelhoResponse>(StatusCodes.Status200OK)
            .RequirePermission("aparelhos:ler");

        group.MapGet("/{clienteId}", async (
                [AsParameters] ListarAparelhosPorClienteRequest request,
                [FromQuery] Guid clienteId,
                IListarAparelhosPorClienteHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(clienteId, request.Normalized(), ct);
                return result.ToHttpResult();
            })
            .Produces<AparelhoResponse>(StatusCodes.Status200OK)
            .RequirePermission("aparelhos:ler");

        group.MapPost("/", async ([FromBody] CriarAparelhoRequest request, ICriarAparelhoHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .Produces<CriarAparelhoResponse>(StatusCodes.Status201Created)
            .RequirePermission("aparelhos:escrever");

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] AtualizarAparelhoRequest request, IAtualizarAparelhoHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, request, ct)).ToHttpResult())
            .Produces(StatusCodes.Status200OK)
            .RequirePermission("aparelhos:escrever");

        group.MapDelete("/{id:guid}", async (Guid id, IExcluirAparelhoHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .Produces(StatusCodes.Status200OK)
            .RequirePermission("aparelhos:escrever");
    }
}
