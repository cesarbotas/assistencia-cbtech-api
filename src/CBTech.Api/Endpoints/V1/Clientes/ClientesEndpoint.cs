using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Clientes.AtualizarCliente;
using CBTech.Application.UseCases.V1.Clientes.ConsultarClientePorId;
using CBTech.Application.UseCases.V1.Clientes.ListarClientes;
using CBTech.Application.UseCases.V1.Clientes.CriarCliente;
using CBTech.Application.UseCases.V1.Clientes.ExcluirCliente;
using CBTech.Domain.Entities.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Clientes;

public static class ClientesEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async (
                [AsParameters] ListarClientesRequest request,
                IListarClientesHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(request.Normalized(), ct);
                return result.ToHttpResult();
            })
            .RequirePermission("clientes:ler");

        group.MapGet("/{id:guid}", async (Guid id, IConsultarClientePorIdHandler handler, CancellationToken ct) =>
                (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("clientes:escrever");

        group.MapPost("/", async ([FromBody] CriarClienteRequest request, ICriarClienteHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .RequirePermission("clientes:escrever");

        group.MapPut("/{id:guid}", async
            (
                Guid id,
                [FromBody] AtualizarClienteRequest request,
                IAtualizarClienteHandler handler,
                CancellationToken ct
            ) =>
            (
                await handler.Handle(id, request, ct)).ToHttpResult()
            )
            .RequirePermission("clientes:escrever");

        group.MapDelete("/{id:guid}", async (Guid id, IExcluirClienteHandler handler, CancellationToken ct) =>
                (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("clientes:escrever");
    }
}
