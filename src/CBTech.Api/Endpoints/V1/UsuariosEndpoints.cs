using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Usuarios.CreateUsuario;
using CBTech.Application.UseCases.V1.Usuarios.DeleteUsuario;
using CBTech.Application.UseCases.V1.Usuarios.GetUsuarioById;
using CBTech.Application.UseCases.V1.Usuarios.ListUsuarios;
using CBTech.Application.UseCases.V1.Usuarios.SetUsuarioAtivo;
using CBTech.Application.UseCases.V1.Usuarios.SetUsuarioRoles;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1;

public static class UsuariosEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async (IListUsuariosHandler handler, CancellationToken ct) =>
            (await handler.Handle(ct)).ToHttpResult())
            .RequirePermission("usuarios:gerenciar");

        group.MapGet("/{id:guid}", async (Guid id, IGetUsuarioByIdHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("usuarios:gerenciar");

        group.MapPost("/", async ([FromBody] CreateUsuarioRequest request, ICreateUsuarioHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created))
            .RequirePermission("usuarios:gerenciar");

        group.MapPut("/{id:guid}/roles", async (Guid id, [FromBody] SetUsuarioRolesRequest request, ISetUsuarioRolesHandler handler, CancellationToken ct) =>
            (await handler.Handle(request with { UsuarioId = id }, ct)).ToHttpResult())
            .RequirePermission("usuarios:gerenciar");

        group.MapPatch("/{id:guid}/ativo", async (Guid id, [FromBody] SetUsuarioAtivoRequest request, ISetUsuarioAtivoHandler handler, CancellationToken ct) =>
            (await handler.Handle(request with { UsuarioId = id }, ct)).ToHttpResult())
            .RequirePermission("usuarios:gerenciar");

        group.MapDelete("/{id:guid}", async (Guid id, IDeleteUsuarioHandler handler, CancellationToken ct) =>
            (await handler.Handle(id, ct)).ToHttpResult())
            .RequirePermission("usuarios:gerenciar");
    }
}
