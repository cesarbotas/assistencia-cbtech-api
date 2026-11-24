using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Produtos;
using CBTech.Application.UseCases.V1.Produtos.AtualizarProduto;
using CBTech.Application.UseCases.V1.Produtos.ConsultarProdutoPorId;
using CBTech.Application.UseCases.V1.Produtos.CriarProduto;
using CBTech.Application.UseCases.V1.Produtos.ExcluirProduto;
using CBTech.Application.UseCases.V1.Produtos.ListarProdutos;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Produtos;

public static class ProdutosEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async ([AsParameters] ProdutosRequest request, IListarProdutosHandler handler, CancellationToken ct) =>
        {
            var query = new ListarProdutosRequest(
                request.Pagina ?? 1,
                request.Tamanho ?? 10,
                request.Search,
                request.CategoriaId,
                request.FornecedorId);
            return (await handler.Handle(query, ct)).ToHttpResult();
        })
            .Produces<ResultadoPaginado<ProdutoResponse>>(StatusCodes.Status200OK)
            .RequirePermission("produtos:ler");

        group.MapGet("/{id:guid}", async (Guid id, IConsultarProdutoPorIdHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("produtos:ler");

        group.MapPost("/", async ([FromBody] CriarProdutoRequest request, ICriarProdutoHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .Produces<CriarProdutoResponse>(StatusCodes.Status201Created)
            .RequirePermission("produtos:escrever");

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] AtualizarProdutoRequest request, IAtualizarProdutoHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, request, ct)).ToHttpResult())
            .RequirePermission("produtos:escrever");

        group.MapDelete("/{id:guid}", async (Guid id, IExcluirProdutoHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("produtos:escrever");
    }
}