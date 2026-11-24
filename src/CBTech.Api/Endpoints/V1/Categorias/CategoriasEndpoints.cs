using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Categorias;
using CBTech.Application.UseCases.V1.Categorias.AtualizarCategoria;
using CBTech.Application.UseCases.V1.Categorias.ConsultarCategoriaPorId;
using CBTech.Application.UseCases.V1.Categorias.CriarCategoria;
using CBTech.Application.UseCases.V1.Categorias.ExcluirCategoria;
using CBTech.Application.UseCases.V1.Categorias.ListarCategorias;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Categorias;

public static class CategoriasEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async ([AsParameters] CategoriasRequest request, IListarCategoriasHandler handler, CancellationToken ct) =>
        {
            var query = new ListarCategoriasRequest(request.Pagina ?? 1, request.Tamanho ?? 10, request.Search);
            return (await handler.Handle(query, ct)).ToHttpResult();
        })
            .Produces<ResultadoPaginado<CategoriaResponse>>(StatusCodes.Status200OK)
            .RequirePermission("categorias:ler");

        group.MapGet("/{id:guid}", async (Guid id, IConsultarCategoriaPorIdHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("categorias:ler");

        group.MapPost("/", async ([FromBody] CriarCategoriaRequest request, ICriarCategoriaHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .Produces<CriarCategoriaResponse>(StatusCodes.Status201Created)
            .RequirePermission("categorias:escrever");

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] AtualizarCategoriaRequest request, IAtualizarCategoriaHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, request, ct)).ToHttpResult())
            .RequirePermission("categorias:escrever");

        group.MapDelete("/{id:guid}", async (Guid id, IExcluirCategoriaHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("categorias:escrever");
    }
}