using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Fornecedores;
using CBTech.Application.UseCases.V1.Fornecedores.AtualizarFornecedor;
using CBTech.Application.UseCases.V1.Fornecedores.ConsultarFornecedorPorId;
using CBTech.Application.UseCases.V1.Fornecedores.ListarFornecedores;
using CBTech.Application.UseCases.V1.Fornecedores.CriarFornecedor;
using CBTech.Application.UseCases.V1.Fornecedores.ExcluirFornecedor;
using CBTech.Domain.Entities.Fornecedores;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Fornecedores;

public static class FornecedoresEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async (
                [AsParameters] ListarFornecedoresRequest request,
                IListarFornecedoresHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(request.Normalized(), ct);
                return result.ToHttpResult();
            })
            .Produces<FornecedorResponse>(StatusCodes.Status200OK)
            .RequirePermission("fornecedores:ler");

        group.MapGet("/{id:guid}", async (Guid id, IConsultarFornecedorPorIdHandler handler, CancellationToken ct) =>
                (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("fornecedores:ler");

        group.MapPost("/", async ([FromBody] CriarFornecedorRequest request, ICriarFornecedorHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .RequirePermission("fornecedores:escrever");

        group.MapPut("/{id:guid}", async
            (
                Guid id,
                [FromBody] AtualizarFornecedorRequest request,
                IAtualizarFornecedorHandler handler,
                CancellationToken ct
            ) =>
            (
                await handler.Handle(id, request, ct)).ToHttpResult()
            )
            .RequirePermission("fornecedores:escrever");

        group.MapDelete("/{id:guid}", async (Guid id, IExcluirFornecedorHandler handler, CancellationToken ct) =>
                (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("fornecedores:escrever");
    }
}
